using Models;

namespace Service.Interface
{
    public interface ICounterService
    {
        Task<Counter> GetCounterWithInit();
        Task<Counter> Increase();
        Task<Counter> Clear();
    }
}
