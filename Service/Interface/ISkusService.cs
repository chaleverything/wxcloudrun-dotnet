using Models;

namespace Service.Interface
{
    public interface ISkusService : IBaseService
    {
        void Increase(SkusDto entity);
        Task<List<SkusDto>> Search(SkusSearch search);
    }
}
