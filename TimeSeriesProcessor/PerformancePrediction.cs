using Microsoft.ML.Data;

namespace TimeSeriesProcessor
{
    class PerformancePrediction
    {
        [VectorType(3)]
        public double[] Prediction { get; set; }
    }
}
