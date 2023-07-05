using Models;

namespace Service.Interface
{
    public interface ILogService
    {
        void Increase(Log entity);
        Task<List<Log>> Search(LogSearch search);
    }
}
