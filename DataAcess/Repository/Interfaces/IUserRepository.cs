using System.Threading.Tasks;
using DataAccess.DTO;

namespace DataAccess.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto> RegisterUser(string userName, string password);
        
        Task<UserDto> LoginUser(string userName, string password);
    }
}
