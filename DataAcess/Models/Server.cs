using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Server
    {
        public int ServerId { get; set; }

        public string ServerName { get; set; }
        public string IpAddress { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
