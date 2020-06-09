using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using DataAccess;
using DataAccess.DTO;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(ApplicationDbContext dbContext,
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> RegisterUser(string userName, string password)
        {

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                return await _userRepository.RegisterUser(userName, password);
            }

            return null;
        }

        public async Task<UserDto> LoginUser(string userName, string password)
        {
            return await _userRepository.LoginUser(userName, password);
        }


        public UserDto GetUserFromClaims(IEnumerable<Claim> claims)
        {
           return new UserDto
           {
               Id = int.Parse(claims.First(c => c.Type == "userid").Value), 
               UserName = claims.First(c => c.Type == "username").Value
           };
        }

    }
}
