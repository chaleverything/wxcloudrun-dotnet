using Models;

namespace Service.Interface
{
    public interface IKeywordHistorysService : IBaseService
    {
        void Increase(KeywordHistorysDto entity);
        void RemoveByOpenId(KeywordHistorysSearch search);
        void RemoveByUnionId(KeywordHistorysSearch search);
        Task<List<KeywordHistorysDto>> FindByOpenId(KeywordHistorysSearch search);
        Task<List<KeywordHistorysDto>> FindByUnionId(KeywordHistorysSearch search);
    }
}
