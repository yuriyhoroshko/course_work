using System;

namespace Business.Models
{
    public class ProcessedCounterItem
    {
        public int Value { get; set; }
        public DateTime Time { get; set; }
        public bool IsAnomaly { get; set; }
        public double Confidence { get; set; }
    }
}
