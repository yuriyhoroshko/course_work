using Microsoft.ML.Data;

namespace Business.Models
{
    public class PerformancePrediction
    {
        [VectorType(3)]
        public double[] Prediction { get; set; }
    }
}
