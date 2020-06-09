using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.DTO;

namespace DataAccess.Repository.Interfaces
{
    public interface ICounterRepository
    {
        void SaveCounterData(CounterDto counter);

        List<CounterDto> GetLatestCountersDistinct(int serverId);

        Task<List<CounterData>> GetCounterData(string counter, int serverId, DateTime beginDate, DateTime endDate);
    }
}
