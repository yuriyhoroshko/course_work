using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;

namespace DataAccess.Repository.Interfaces
{
    public interface IServerRepository
    {
        Task<ServerDto> AddServer(string serverName, string ipAddress, int userId);

        Task<int> GetServerByName(string name, int userId);

        Task<List<ServerDto>> GetServersByUser(int userId);

        Task<bool> IsServerBelongsToUser(int userId, int serverId);
    }
}
