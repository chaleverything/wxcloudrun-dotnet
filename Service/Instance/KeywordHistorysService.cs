using AutoMapper;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Service.Interface;

namespace Service.Instance
{
    public class KeywordHistorysService: IKeywordHistorysService
    {
        private readonly KeywordHistorysContext _context;
        private readonly IMapper _mapper;

        public KeywordHistorysService(KeywordHistorysContext context, IMapper mapper)
        {
            _context = context;
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
            var query = _context.KeywordHistorys.AsNoTracking().Where(n=> n.openId == search.openId);
            return _mapper.Map<List<KeywordHistorysDto>>(await query.OrderByDescending(n => n.creationTime).ToListAsync());
        }

        public async Task<List<KeywordHistorysDto>> FindByUnionId(KeywordHistorysSearch search)
        {
            var query = _context.KeywordHistorys.AsNoTracking().Where(n => n.unionId == search.unionId);
            return _mapper.Map<List<KeywordHistorysDto>>(await query.OrderByDescending(n => n.creationTime).ToListAsync());
        }
    }
}