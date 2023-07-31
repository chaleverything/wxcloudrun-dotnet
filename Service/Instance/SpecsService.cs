using AutoMapper;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Service.Interface;

namespace Service.Instance
{
    public class SpecsService: ISpecsService
    {
        private readonly SpecsContext _context;
        private readonly IMapper _mapper;

        public SpecsService(SpecsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Increase(SpecsDto dto)
        {
            dto.creationTime = DateTime.Now;
            var entity = _mapper.Map<Specs>(dto);
            _context.Specs.Add(entity);
            var unused = _context.SaveChanges();
        }

        public async Task<List<SpecsDto>> Search(SpecsSearch search)
        {
            var query = _context.Specs.AsNoTracking();
            if (search.goodsIds?.Count > 0)
            {
                query = query.Where(n => n.goodsId.HasValue && search.goodsIds.Contains(n.goodsId.Value));
            }

            return _mapper.Map<List<SpecsDto>>(await query.OrderBy(n => n.index).ToListAsync());
        }
    }
}