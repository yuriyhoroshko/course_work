using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DTO
{
    public class CounterDto
    {
        public int CounterId { get; set; }

        public DateTime Time { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public int ServerId { get; set; }
    }
}
