using AutoMapper;
using Common.Utilities;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Service.Interface;

namespace Service.Instance
{
    public class GoodsService: IGoodsService
    {
        private readonly GoodsContext _context;
        private readonly IMapper _mapper;

        public GoodsService(GoodsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Increase(GoodsDto dto)
        {
            dto.creationTime = DateTime.Now;
            var entity = _mapper.Map<Goods>(dto);
            _context.Goods.Add(entity);
            var unused = _context.SaveChanges();
        }

        public async Task<(List<GoodsDto>, int)> Search(GoodsSearch search)
        {
            var query = _context.Goods.AsNoTracking().Where(n => !n.cancelTime.HasValue);
            (int total, int currentPage, int linePerPage, string orderByField, string direction) = search.GetDefaultCondition();
            if (search.lstStoreId?.Count > 0)
            {
                query = query.Where(n => n.storeId.HasValue && search.lstStoreId.Contains(n.storeId.Value));
            }
            if (!string.IsNullOrWhiteSpace(search.title))
            {
                query = query.Where(n => n.title != null && n.title.Contains(search.title));
            }
            if (search.available.HasValue)
            {
                query = query.Where(n => n.available == search.available);
            }
            if (search.isPutOnSale.HasValue)
            {
                query = query.Where(n => n.isPutOnSale == search.isPutOnSale);
            }

            total = query.Count();

            // .SortBy($"{orderByField} {direction}");
            query = query.OrderByDescending(n=>n.soldNum).ThenByDescending(n=>n.hitQuantity).ThenByDescending(n=>n.stockQuantity).Skip((currentPage - 1) * linePerPage).Take(linePerPage);
            return (_mapper.Map<List<GoodsDto>>(await query.ToListAsync()), total);
        }
    }
}