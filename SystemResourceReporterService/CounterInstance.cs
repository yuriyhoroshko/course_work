using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Contract;
using Newtonsoft.Json;
using SettingsProvider;

namespace SystemResourceReporterService
{
    public class CounterInstance
    {
        private readonly StringBuilder counterBuffer;
        private readonly PerformanceCounter performanceCounter;
        private readonly string filePath;
        private readonly string customName;
        private readonly int divider;
        private readonly Settings settings;

        private string token = "";
        private bool isUploadRunning = false;

        public CounterInstance(Settings settings, string categoryName, string counterName, string folderPath, string customName,
            string instanceName = null, int divider = 1)
        {
            this.settings = settings;
            this.customName = customName;

            counterBuffer = new StringBuilder();
            this.divider = divider;
            performanceCounter = string.IsNullOrEmpty(instanceName)
                ? new PerformanceCounter(categoryName, counterName)
                : new PerformanceCounter(categoryName, counterName, instanceName);

            var regex = new Regex(@"[\\/:*?""<>| %]");

            var normalizedName = regex.Replace(customName, "_");
            filePath = folderPath + $"\\{normalizedName}.csv";

            CheckFileExistence(filePath);
        }

        public void AppendDataToBuffer()
        {
            var currentTime = DateTime.UtcNow;
            var currentUsage = (int)(performanceCounter.NextValue() / divider);

            lock (counterBuffer)
            {
                counterBuffer.AppendLine(
                    $"{currentTime.ToString(CultureInfo.CurrentCulture)},{currentUsage}");
            }
        }

        public void FlushCounterBuffer()
        {
            if(isUploadRunning)
                return;

            CheckFileExistence(filePath);

            lock (counterBuffer)
            {
                try
                {
                    File.AppendAllText(filePath, counterBuffer.ToString());
                    counterBuffer.Clear();
                }
                catch { }
            }
        }

        public async void UploadToServer(string token)
        {
            try
            {
                isUploadRunning = true;

                var counterData = ReadDataFromFile();

                var chunks = SplitIntoChunks(counterData, 100);

                Parallel.ForEach(chunks, async chunk => { await UploadData(chunk, token); });

                DeleteFile();

                isUploadRunning = false;
            }
            catch
            {
                isUploadRunning = false;
            }
        }

        private void CheckFileExistence(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        private List<CounterData> ReadDataFromFile()
        {
            var dictionary = new List<CounterData>();

            if (File.Exists(filePath))
            {
                lock (counterBuffer)
                {
                    var lines = File.ReadAllLines(filePath);

                    foreach (var line in lines)
                    {
                        var pieces = line.Split(',');

                        dictionary.Add(new CounterData
                        {
                            TimeStamp = DateTime.Parse(pieces[0], CultureInfo.CurrentCulture),
                            Value = int.Parse(pieces[1])
                        });
                    }

                    return dictionary;
                }
            }

            return null;
        }

        private async Task UploadData(List<CounterData> data, string token)
        {
            var uploadObj = new CounterUploadModel
            {
                CounterData = data,
                CounterName = customName,
                ServerName = settings.ServerName
            };

            var serialized = JsonConvert.SerializeObject(uploadObj);

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization
                        = new AuthenticationHeaderValue("Bearer", token);

                    var response = await client.PostAsync(Urls.BaseUrl + Urls.UploadCounterDataUrl, content);

                }
            }
            catch { }
        }

        private List<List<CounterData>> SplitIntoChunks(List<CounterData> counterData, int size)
        {
            var chunksCount = counterData.Count % size > 0
                ? counterData.Count / size + 1
                : counterData.Count / size;

            var chunks = new List<List<CounterData>>();

            for (int i = 0; i < chunksCount; i++)
            {
                var numberOfElements = counterData.Count - i * size;

                chunks.Add(counterData.GetRange(i * size, i == chunksCount-1 ? numberOfElements : size));
            }

            return chunks;
        }
      
        private void DeleteFile()
        {
            File.Delete(filePath);
        }
    }
}
