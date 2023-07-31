using Models;

namespace Service.Interface
{
    public interface ISpecValsService : IBaseService
    {
        void Increase(SpecValsDto entity);
        Task<List<SpecValsDto>> Search(SpecValsSearch search);
    }
}
