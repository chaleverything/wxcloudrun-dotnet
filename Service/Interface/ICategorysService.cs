using Models;

namespace Service.Interface
{
    public interface ICategorysService : IBaseService
    {
        void Increase(CategorysDto category);
        Task<List<CategorysDto>> Search(CategorysSearch search);
        Task<List<CategorysDto>> GetAll();
    }
}
