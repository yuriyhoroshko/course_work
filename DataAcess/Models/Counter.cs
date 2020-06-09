using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Counter
    { 
        public int CounterId { get; set; }

        public DateTime Time { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        [ForeignKey("Server")]
        public int ServerId { get; set; }

        public Server Server { get; set; }
    }
}