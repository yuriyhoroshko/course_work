using System.Collections.Generic;

namespace DataAccess.DTO
{
    public class ServerDto
    {
        public int ServerId { get; set; }

        public string ServerName { get; set; }

        public string IpAddress { get; set; }

        public int UserId { get; set; }

        public List<CounterDto> Counters { get; set; }
    }
}
