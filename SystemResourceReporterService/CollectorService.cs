using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;
using SettingsProvider;

namespace SystemResourceReporterService
{
    public class SystemInfoCollectorService: ServiceBase
    {
        private Settings _settings;

        private Timer _collectionTimer;
        private Timer _flushTimer;
        private Timer _uploadTimer;

        private Collector _collector;
        protected override void OnStart(string[] args)
        {
            try
            {
                _settings = new Serializer().ReadSettings();

                _collector = new Collector(_settings);

                _collectionTimer = new Timer(CollectData, null, TimeSpan.FromSeconds(0),
                    TimeSpan.FromSeconds(_settings.CollectionCycleSeconds));
                _flushTimer = new Timer(FlushData, null, TimeSpan.FromSeconds(_settings.CollectionCycleSeconds + 5),
                    TimeSpan.FromSeconds(_settings.CollectionCycleSeconds * 2));
                _uploadTimer = new Timer(UploadData, null, TimeSpan.FromMinutes(_settings.UploadCycleMinutes),
                    TimeSpan.FromMinutes(_settings.UploadCycleMinutes));
            }
            catch (Exception e)
            {
                LoggerInstance.Log.Error(e.Message);
            }
        }

        protected override void OnStop()
        {
            _collectionTimer.Dispose();
            _flushTimer.Dispose();
            _uploadTimer.Dispose();

            _collector.FlushCounterBuffers();
            _collector.UploadData();
        }

        private void CollectData(object payload)
        {
            _collector.AppendData();
        }
        
        private void FlushData(object payload)
        {
            _collector.FlushCounterBuffers();
        }
        private void UploadData(object payload)
        {
            _collector.UploadData();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        private void InitializeComponent()
        {
            // 
            // SystemInfoCollectorService
            // 
            this.ServiceName = "System Performance Collector Service";

        }
    }
}
