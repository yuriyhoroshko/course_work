using System.Linq;
using System.Threading.Tasks;
using Business.Services.Interfaces;
using Contract;
using DataAccess.DTO;
using DataAccess.Repository.Interfaces;

namespace Business.Services
{
    public class CounterService: ICounterService
    {
        private readonly ICounterRepository _counterRepository;
        private readonly IServerRepository _serverRepository;

        public CounterService(ICounterRepository counterRepository,
            IServerRepository serverRepository)
        {
            _counterRepository = counterRepository;
            _serverRepository = serverRepository;
        }

        public async Task UploadData(CounterUploadModel counter, int userId)
        {
            var serverId = await _serverRepository.GetServerByName(counter.ServerName, userId);

            var counters = counter.CounterData.Select(c =>
                new CounterDto
                {
                    Name = counter.CounterName,
                    Time = c.TimeStamp,
                    Value = c.Value,
                    ServerId = serverId
                });

            Parallel.ForEach(counters, c => _counterRepository.SaveCounterData(c));
        }
    }
}
