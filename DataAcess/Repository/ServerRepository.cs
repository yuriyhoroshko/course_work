using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DTO;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class ServerRepository: IServerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ServerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ServerDto> AddServer(string serverName, string ipAddress, int userId)
        {
            try
            {
                await using (_dbContext)
                {
                    var server = new Server
                    {
                        UserId = userId,
                        IpAddress = ipAddress,
                        ServerName = serverName
                    };

                    _dbContext.Servers.Add(server);
                    await _dbContext.SaveChangesAsync();

                    return new ServerDto
                    {
                        UserId = server.UserId,
                        IpAddress = server.IpAddress,
                        ServerName = server.ServerName,
                        ServerId = server.ServerId
                    };
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> GetServerByName(string name, int userId)
        {
            try
            {
                using (_dbContext)
                {
                    var server =
                        await _dbContext.Servers.FirstOrDefaultAsync(s => s.UserId == userId && s.ServerName == name);

                    return server.ServerId;
                }
            }
            catch
            {
                return 0;
            }
        }

        public async Task<List<ServerDto>> GetServersByUser(int userId)
        {
            try
            {
                await using (_dbContext)
                {
                    return await _dbContext.Servers.Where(server => server.UserId == userId).Select(s => new ServerDto
                    {
                        UserId = s.UserId,
                        IpAddress = s.IpAddress,
                        ServerName = s.ServerName,
                        ServerId = s.ServerId
                    }).ToListAsync();
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> IsServerBelongsToUser(int userId, int serverId)
        {
            await using (_dbContext)
            {
                return await _dbContext.Servers.CountAsync(server => server.UserId == userId && server.ServerId == serverId) >
                       0;
            }
        }
    }
}
