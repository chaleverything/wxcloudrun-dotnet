using Models;

namespace Service.Interface
{
    public interface ILogService
    {
        void Increase(LogDto log);
        Task<List<LogDto>> Search(LogSearch search);
    }
}
