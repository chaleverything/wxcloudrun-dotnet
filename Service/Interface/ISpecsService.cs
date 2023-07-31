using Models;

namespace Service.Interface
{
    public interface ISpecsService : IBaseService
    {
        void Increase(SpecsDto entity);
        Task<List<SpecsDto>> Search(SpecsSearch search);
    }
}
