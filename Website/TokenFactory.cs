using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.DTO;
using Microsoft.IdentityModel.Tokens;

namespace Website
{
    public class TokenFactory
    {
        public string CreateToken(UserDto user)
        {
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: DateTime.UtcNow,
                claims: GetClaims(user),
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(AuthOptions.LifeTime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private List<Claim> GetClaims(UserDto user)
        {
            return new List<Claim>
            {
                new Claim("username", user.UserName),
                new Claim("userid", user.Id.ToString())
            };
        }
    }
}
