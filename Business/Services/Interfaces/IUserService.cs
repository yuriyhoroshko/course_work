using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccess.DTO;

namespace Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterUser(string userName, string password);
        
        Task<UserDto> LoginUser(string userName, string password);

        UserDto GetUserFromClaims(IEnumerable<Claim> claims);
    }
}
