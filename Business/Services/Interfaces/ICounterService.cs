using Contract;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ICounterService
    {
        Task UploadData(CounterUploadModel counter, int userId);
    }
}
