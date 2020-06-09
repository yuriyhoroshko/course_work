using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DTO;
using DataAccess.Models;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class CounterRepository: ICounterRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private object locker = new object();

        public CounterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveCounterData(CounterDto counter)
        {
            lock (locker)
            {
                _dbContext.Counters.Add(new Counter
                    {
                        Name = counter.Name,
                        ServerId = counter.ServerId,
                        Time = counter.Time,
                        Value = counter.Value
                    });

                    _dbContext.SaveChanges();
            }
        }

        //todo: too slow
        public List<CounterDto> GetLatestCountersDistinct(int serverId)
        {
            return _dbContext.Counters.Where(counter => counter.ServerId == serverId)
                .OrderBy(counter => counter.Time).AsEnumerable().GroupBy(counter => counter.Name).Select(
                    g => new CounterDto
                    {
                        ServerId = g.First().ServerId,
                        Time = g.First().Time,
                        Name = g.First().Name,
                        Value = g.First().Value,
                        CounterId = g.First().CounterId
                    }).ToList();
        }

        public async Task<List<CounterData>> GetCounterData(string counterName, int serverId, DateTime beginDate, DateTime endDate)
        {
            return await _dbContext.Counters
                .Where(counter => counter.Name == counterName && counter.ServerId == serverId &&
                                  (counter.Time > beginDate && counter.Time < endDate)).Select(counter =>
                    new CounterData
                    {
                        Counter = counter.Value,
                        Date = counter.Time
                    }).OrderBy(counter => counter.Date).ToListAsync();
        }

        ~CounterRepository() 
        { 
            _dbContext.Dispose();
        }
    }
}
