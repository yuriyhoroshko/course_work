using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Website
{
    public class AuthOptions
    {
        public const string Issuer = "performanceWebsite";
        public const string Audience = "PerformanceWebsiteClient";
        const string Key = "weryStronG_and_coolKey_53183282193";
        public const int LifeTime = 30; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
