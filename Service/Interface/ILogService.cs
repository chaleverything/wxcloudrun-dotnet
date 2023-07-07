using Models;

namespace Service.Interface
{
    public interface ILogService : IBaseService
    {
        void Increase(LogDto log);
        Task<List<LogDto>> Search(LogSearch search);
    }
}
