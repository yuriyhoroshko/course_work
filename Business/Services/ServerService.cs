using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using DataAccess.DTO;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Services
{
    public class ServerService: IServerService
    {
        private readonly IServerRepository _serverRepository;
        private readonly ICounterRepository _counterRepository;

        public ServerService(IServerRepository serverRepository, ICounterRepository counterRepository)
        {
            _serverRepository = serverRepository;
            _counterRepository = counterRepository;
        }

        public async Task<ServerDto> AddServer(string serverName, string ipAddress, int userId)
        {
            return await _serverRepository.AddServer(serverName, ipAddress, userId);
        }

        public async Task<List<ServerDto>> GetServersForUser(int userId)
        {
            var servers =  await _serverRepository.GetServersByUser(userId);
            return servers.Select(s => new ServerDto
            {
                UserId = s.UserId,
                IpAddress = s.IpAddress,
                ServerName = s.ServerName,
                ServerId = s.ServerId,
                Counters = _counterRepository.GetLatestCountersDistinct(s.ServerId)
            }).ToList();
        }

        public async Task<bool> IsServerBelongsToUser(int userId, int serverId)
        {
            return await _serverRepository.IsServerBelongsToUser(userId, serverId);
        }
    }
}
