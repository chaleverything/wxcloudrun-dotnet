using AutoMapper;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Service.Interface;

namespace Service.Instance
{
    public class SkusService: ISkusService
    {
        private readonly SkusContext _context;
        private readonly IMapper _mapper;

        public SkusService(SkusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Increase(SkusDto dto)
        {
            dto.creationTime = DateTime.Now;
            var entity = _mapper.Map<Skus>(dto);
            _context.Skus.Add(entity);
            var unused = _context.SaveChanges();
        }

        public async Task<List<SkusDto>> Search(SkusSearch search)
        {
            var query = _context.Skus.AsNoTracking();
            if (search.goodsIds?.Count > 0)
            {
                query = query.Where(n => n.goodsId.HasValue && search.goodsIds.Contains(n.goodsId.Value));
            }

            return _mapper.Map<List<SkusDto>>(await query.OrderBy(n => n.index).ToListAsync());
        }
    }
}