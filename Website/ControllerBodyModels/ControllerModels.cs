using System;
using Business.Models;

namespace Website.ControllerBodyModels
{
    public class UserCredentials
    {
        public string UserName { get; set; }
        
        public string Password { get; set; }
    }

    public class ServerInfo
    {
        public string IpAddress { get; set; }
        
        public string ServerName { get; set; }
    }

    public class PredictionOptions
    {
        public DateTime BeginDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public int ServerId { get; set; } 
        
        public string CounterName { get; set; }
        
        public DetectionOptions Options { get; set; }
    }
}
