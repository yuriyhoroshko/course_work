using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;

namespace Business.Services.Interfaces
{
    public interface IServerService
    {
        Task<ServerDto> AddServer(string serverName, string ipAddress, int userId);

        Task<List<ServerDto>> GetServersForUser(int userId);

        Task<bool> IsServerBelongsToUser(int userId, int serverId);
    }
}
