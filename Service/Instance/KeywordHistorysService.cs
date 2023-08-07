using AutoMapper;
using Common.Utilities;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Newtonsoft.Json;
using Service.Interface;

namespace Service.Instance
{
    public class KeywordHistorysService: IKeywordHistorysService
    {
        private readonly KeywordHistorysContext _context;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public KeywordHistorysService(KeywordHistorysContext context, ILogService logService, IMapper mapper)
        {
            _context = context;
            _logService = logService;
            _mapper = mapper;
        }

        public void Increase(KeywordHistorysDto dto)
        {
            dto.creationTime = DateTime.Now;
            var entity = _mapper.Map<KeywordHistorys>(dto);
            _context.KeywordHistorys.Add(entity);
            var unused = _context.SaveChanges();
        }

        public void RemoveByOpenId(KeywordHistorysSearch search)
        {
            var lst = _context.KeywordHistorys.Where(n => n.openId == search.openId).ToList();
            _context.KeywordHistorys.RemoveRange(lst);
            var unused = _context.SaveChanges();
        }
        public void RemoveByUnionId(KeywordHistorysSearch search)
        {
            var lst = _context.KeywordHistorys.Where(n => n.openId == search.openId).ToList();
            _context.KeywordHistorys.RemoveRange(lst);
            var unused = _context.SaveChanges();
        }

        public async Task<List<KeywordHistorysDto>> FindByOpenId(KeywordHistorysSearch search)
        {
            (int total, int pageIndex, int pageSize, string sortBy, string direction) = search.GetDefaultCondition();
            _logService.Increase(new LogDto { subject = "FindByUnionId", message = $"[pageIndex:{pageIndex}][pageSize:{pageSize}]" });
            var query = _context.KeywordHistorys.AsNoTracking().Where(n=> n.openId == search.openId);
            return _mapper.Map<List<KeywordHistorysDto>>(await query.OrderByDescending(n => n.creationTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync());
        }

        public async Task<List<KeywordHistorysDto>> FindByUnionId(KeywordHistorysSearch search)
        {
            (int total, int pageIndex, int pageSize, string sortBy, string direction) = search.GetDefaultCondition();
            _logService.Increase(new LogDto { subject = "FindByUnionId", message = $"[pageIndex:{pageIndex}][pageSize:{pageSize}]" });
            var query = _context.KeywordHistorys.AsNoTracking().Where(n => n.unionId == search.unionId);
            return _mapper.Map<List<KeywordHistorysDto>>(await query.OrderByDescending(n => n.creationTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync());
        }

        public async Task<KeywordHistorysDto?> FindContentByOpenId(KeywordHistorysSearch search)
        {
            if(string.IsNullOrWhiteSpace(search.openId) || string.IsNullOrWhiteSpace(search.content))
            {
                return null;
            }

            var query = _context.KeywordHistorys.AsNoTracking().Where(n => n.openId == search.openId && n.content == search.content.Trim());
            return _mapper.Map<KeywordHistorysDto>(await query.FirstOrDefaultAsync());
        }


        public async Task<KeywordHistorysDto?> FindContentByUnionId(KeywordHistorysSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.unionId) || string.IsNullOrWhiteSpace(search.content))
            {
                return null;
            }

            var query = _context.KeywordHistorys.AsNoTracking().Where(n => n.unionId == search.unionId && n.content == search.content.Trim());
            return _mapper.Map<KeywordHistorysDto>(await query.FirstOrDefaultAsync());
        }


        public async Task<List<string>> GetPopulars(SearchBase search)
        {
            (int total, int pageIndex, int pageSize, string sortBy, string direction) = search.GetDefaultCondition();
#pragma warning disable CS8602 // 解引用可能出现空引用。
            var query = _context.KeywordHistorys.AsNoTracking()
                .GroupBy(m => new { m.content })
                .Select(n => new KeywordHistorysSummary
                {
                    content = n.Key.content,
                    number = n.Count(),
                    creationTime = n.Where(k => k.creationTime.HasValue).OrderBy(k => k.creationTime).FirstOrDefault().creationTime
                });
#pragma warning restore CS8602 // 解引用可能出现空引用。

            var result = await query.OrderByDescending(n => n.number).ThenBy(n => n.creationTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(n => n.content).ToListAsync();
            return _mapper.Map<List<string>>(result);
        }
    }
}