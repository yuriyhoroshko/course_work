using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Models;
using Business.Services.Interfaces;
using DataAccess.DTO;
using DataAccess.Repository.Interfaces;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace Business.Services
{
    public class TimeSeriesService: ITimeSeriesService
    {
        private MLContext mlContext;
        private DetectionOptions options;

        private readonly ICounterRepository _counterRepository;

        public TimeSeriesService(ICounterRepository counterRepository)
        {
            mlContext = new MLContext();
            _counterRepository = counterRepository;
        }

        public async Task<List<ProcessedCounterItem>> GetDataForCounter(DetectionOptions options, string counter, int serverId, DateTime beginDate, DateTime endDate)
        {
            this.options = options;

            var data = await _counterRepository.GetCounterData(counter, serverId, beginDate, endDate);
            var contextData = mlContext.Data.LoadFromEnumerable(data.ToArray());

            return options.Algorithm == DetectionAlgorithms.SSA
                ? DetectBySSA(contextData, data)
                : DetectBySRCNN(contextData, data);
        }

        private List<ProcessedCounterItem> DetectBySSA(IDataView data, List<CounterData> rawData)
        {
            var pipeline = mlContext.Transforms.DetectSpikeBySsa(nameof(PerformancePrediction.Prediction),
                nameof(CounterData.Counter),
                options.Confidence,
                trainingWindowSize: options.TrainingWindowSize,
                seasonalityWindowSize: options.SeasonalityWindowSize,
                pvalueHistoryLength: options.PValueHistoryLength);

            var transformed = pipeline.Fit(data).Transform(data);

            var predictions = mlContext.Data.CreateEnumerable<PerformancePrediction>(transformed, reuseRowObject: false).ToList();

            var processedItems = new List<ProcessedCounterItem>();

            for (int i = 0; i < predictions.Count(); i++)
            {
                processedItems.Add(new ProcessedCounterItem
                {
                    IsAnomaly = (int)predictions[i].Prediction[0] == 1,
                    Time = rawData[i].Date,
                    Value = (int)rawData[i].Counter,
                    Confidence = predictions[i].Prediction[2]
                });
            }

            return processedItems;
        }

        private List<ProcessedCounterItem> DetectBySRCNN(IDataView data, List<CounterData> rawData)
        {
            var pipeline = mlContext.Transforms.DetectAnomalyBySrCnn(nameof(PerformancePrediction.Prediction),
                nameof(CounterData.Counter),
                windowSize: options.WindowSize,
                judgementWindowSize: options.JudgementWindowSize,
                threshold: options.Threshold);

                var transformed = pipeline.Fit(data).Transform(data);

            var predictions = mlContext.Data.CreateEnumerable<PerformancePrediction>(transformed, reuseRowObject: false).ToList();

            var processedItems = new List<ProcessedCounterItem>();

            for (int i = 0; i < predictions.Count(); i++)
            {
                processedItems.Add(new ProcessedCounterItem
                {
                    IsAnomaly = (int)predictions[i].Prediction[0] == 1,
                    Time = rawData[i].Date,
                    Value = (int)rawData[i].Counter,
                    Confidence = predictions[i].Prediction[1]
                });
            }

            return processedItems;
        }
    }
}
