using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccess.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
