using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML;

namespace Business.Models
{
    public class DetectionOptions
    {
        public DetectionAlgorithms Algorithm { get; set; }
        public int Confidence { get; set; }
        public int TrainingWindowSize { get; set; }
        public int SeasonalityWindowSize { get; set; }
        public int PValueHistoryLength { get; set; }
        public int WindowSize { get; set; }
        public double Threshold { get; set; }
        public int JudgementWindowSize { get; set; }

    }

    public enum DetectionAlgorithms
    {
        SSA,
        SRCNN
    }
}
