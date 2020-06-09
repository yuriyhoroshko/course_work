using System;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Calibrators;
using Microsoft.ML.Data;
using PLplot;

namespace TimeSeriesProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MLContext();

            var data = context.Data.LoadFromTextFile<PerformanceData>("../../../Processor_Time.csv", hasHeader: false,
                separatorChar:',');

            var pipeline = context.Transforms.DetectSpikeBySsa(nameof(PerformancePrediction.Prediction),
                nameof(PerformanceData.Counter),
                90,
                trainingWindowSize: 200,
                seasonalityWindowSize: 50,
                pvalueHistoryLength: (int)(data.GetRowCount()/4));

            var transformedData = pipeline.Fit(data).Transform(data);

            var predictions = context.Data
                .CreateEnumerable<PerformancePrediction>(transformedData, reuseRowObject: false).ToList();

            var date = data.GetColumn<DateTime>("Date").ToArray();
            var counter = data.GetColumn<float>("Counter").ToArray();

            for (int i = 0; i < predictions.Count; i++)
            {
                if (predictions[i].Prediction[0] == 1)
                {
                    Console.WriteLine($"{date[i]}, {predictions[i].Prediction[1]}|{counter[i]} confidence:{predictions[i].Prediction[2]}");
                }
            }
            //todo: improce algo
            var pl = new PLStream();
            pl.sdev("pngcairo");
            pl.sfnam("data.png");
            pl.spal0("cmap0_alternate.pal");    // alternate color palette
            pl.init();
            pl.env(
                800, 1200,                          // x-axis range
                0, 140,                         // y-axis range
                AxesScale.Independent,          // scale x and y independently
                AxisBox.BoxTicksLabelsAxes);    // draw box, ticks, and num ticks
            pl.lab(
                "Date",                         // x-axis label
                "CPU Load",                        // y-axis label
                "CPU load over time");

            pl.line(
                Enumerable.Range(0, counter.Length).Select(i => (double) i).ToArray(),
                counter.Select(c => (double) c).ToArray());

            var spikes = Enumerable.Range(0, predictions.Count).Where(i => (int) predictions[i].Prediction[0] == 1)
                .Select(
                    i => new
                    {
                        DateTime = i,
                        CpuLoad = counter[i]
                    });
            pl.col0(2);
            pl.schr(3,3);
            pl.string2(spikes.Select(s => (double)s.DateTime).ToArray(),
                spikes.Select(s => (double)(s.CpuLoad + 10)).ToArray(), "↓");
            pl.eop();
        }
    }
}
