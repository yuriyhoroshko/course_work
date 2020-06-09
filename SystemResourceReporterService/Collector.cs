using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SettingsProvider;

namespace SystemResourceReporterService
{
    public class Collector
    {
        private List<CounterInstance> counters = new List<CounterInstance>();
        private readonly Settings _settings;
        private string token = String.Empty;

        public Collector(Settings settings)
        {
            _settings = settings;

            if (!Directory.Exists(settings.FolderPath))
            {
                Directory.CreateDirectory(settings.FolderPath);
            }

            var task = TryLogin();
            task.Wait();

            settings.CounterIdentifiers.ForEach(counterIdentifier =>
            {
                counters.Add(new CounterInstance(
                    settings,
                    counterIdentifier.Category,
                    counterIdentifier.Counter,
                    settings.FolderPath,
                    counterIdentifier.CustomName,
                    counterIdentifier.Instance,
                    counterIdentifier.CustomDivider));
            });
        }

        public void AppendData()
        {
            Parallel.ForEach(counters, counter => counter.AppendDataToBuffer());
        }

        public void FlushCounterBuffers()
        {
            Parallel.ForEach(counters, counter => counter.FlushCounterBuffer());
        }

        public void UploadData()
        {
            Parallel.ForEach(counters, counter => counter.UploadToServer(token));
        }

        private async Task TryLogin()
        {
            try
            {
                using (var client = new HttpClient())
                {

                    var content =
                        new StringContent(
                            "{" + $"\"userName\": \"{_settings.UserName}\",\"password\": \"{_settings.Password}\"" +
                            "}",
                            Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(Urls.BaseUrl + Urls.LoginUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var body = await GetBody(response);

                        token = body.Token;
                    }
                }
            }
            catch { }
        }
        private async Task<ResponseBody> GetBody(HttpResponseMessage response)
        {
            var str = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResponseBody>(str);
        }
        class ResponseBody
        {
            public string UserName { get; set; }
            public string Token { get; set; }
        }
    }
}
