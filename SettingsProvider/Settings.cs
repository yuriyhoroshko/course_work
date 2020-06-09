
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace SettingsProvider
{
    [Serializable]
    public class Settings
    {
        public List<CounterIdentifier> CounterIdentifiers { get; set; } = new List<CounterIdentifier>();

        public int CollectionCycleSeconds { get; set; } = 1;

        public int UploadCycleMinutes { get; set; } = 10;

        public string FolderPath { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ServerName { get; set; }
    }
}
