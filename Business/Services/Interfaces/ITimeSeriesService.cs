using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Services.Interfaces
{
    public interface ITimeSeriesService
    {
        Task<List<ProcessedCounterItem>> GetDataForCounter(DetectionOptions options, string counter, int serverId,
            DateTime beginDate, DateTime endDate);
    }
}
