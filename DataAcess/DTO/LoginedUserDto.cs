using System;

namespace DataAccess.DTO
{
    [Serializable]
    public class LoggedUserDto
    {
      public string UserName { get; set; }

      public string Token { get; set; }
    }
}
