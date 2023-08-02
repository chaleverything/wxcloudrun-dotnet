using Models;

namespace Service.Interface
{
    public interface ITabsService : IBaseService
    {
        void Increase(TabsDto entity);
        Task<List<TabsDto>> Search(TabsSearch search);
    }
}
