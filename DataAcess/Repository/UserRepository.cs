using System.Threading.Tasks;
using DataAccess.DTO;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> RegisterUser(string userName, string password)
        {
            using (_dbContext)
            {
                try
                {
                    var user = new User
                    {
                        UserName = userName,
                        Password = password
                    };
                    _dbContext.Add(user);
                    await _dbContext.SaveChangesAsync();

                    return new UserDto
                    {
                        UserName = user.UserName,
                        Id = user.UserId
                    };
                }
                catch
                {
                    return null;
                }
            }
        }

        public async Task<UserDto> LoginUser(string userName, string password)
        {
            using (_dbContext)
            {
                try
                {
                    var user = await _dbContext.Users.FirstOrDefaultAsync(u =>
                        u.UserName == userName && u.Password == password);

                    return new UserDto
                    {
                        UserName = user.UserName,
                        Id = user.UserId
                    };
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}
