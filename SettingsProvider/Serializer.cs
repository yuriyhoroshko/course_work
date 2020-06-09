using System;
using System.IO;
using Newtonsoft.Json;

namespace SettingsProvider
{
    public class Serializer
    {
        private readonly string _settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                                                @"\performanceCounterSettings.json";
        private readonly JsonSerializer _serializer = JsonSerializer.Create();

        public void StoreSettings(Settings settings)
        {
            var serialized = JsonConvert.SerializeObject(settings);

            File.WriteAllText(_settingsPath, serialized);
        }

        public Settings ReadSettings()
        {
            if (TestPath())
            {
                var settingsJson = File.ReadAllText(_settingsPath);

                return JsonConvert.DeserializeObject<Settings>(settingsJson);
            }

            return null;
        }

        private bool TestPath()
        {
            return File.Exists(_settingsPath);
        }
    }
}
