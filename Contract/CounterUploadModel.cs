using System;
using System.Collections.Generic;

namespace Contract
{
    public class CounterUploadModel
    {
        public string ServerName { get; set; }

        public string CounterName { get; set; }

        public List<CounterData> CounterData { get; set; }

    }

    public class CounterData
    {
        public int Value { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
