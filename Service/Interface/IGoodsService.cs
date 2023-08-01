using Models;

namespace Service.Interface
{
    public interface IGoodsService : IBaseService
    {
        void Increase(GoodsDto entity);
        Task<(List<GoodsDto>, int)> Search(GoodsSearch search);
    }
}
