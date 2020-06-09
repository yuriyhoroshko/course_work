using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace TimeSeriesProcessor
{
    class PerformanceData
    {
        [LoadColumn(0)]
        public DateTime Date { get; set; }
        
        [LoadColumn(1)]
        public float Counter { get; set; }
    }
}
