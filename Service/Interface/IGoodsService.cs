using Models;

namespace Service.Interface
{
    public interface IGoodsService : IBaseService
    {
        void Increase(GoodsDto entity);
        Task<List<GoodsDto>> Search(GoodsSearch search);
    }
}
