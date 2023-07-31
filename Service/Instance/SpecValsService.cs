using AutoMapper;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Service.Interface;

namespace Service.Instance
{
    public class SpecValsService: ISpecValsService
    {
        private readonly SpecValsContext _context;
        private readonly IMapper _mapper;

        public SpecValsService(SpecValsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Increase(SpecValsDto dto)
        {
            dto.creationTime = DateTime.Now;
            var entity = _mapper.Map<SpecVals>(dto);
            _context.SpecVals.Add(entity);
            var unused = _context.SaveChanges();
        }

        public async Task<List<SpecValsDto>> Search(SpecValsSearch search)
        {
            var query = _context.SpecVals.AsNoTracking();
            if (search.specIds?.Count > 0)
            {
                query = query.Where(n => n.specId.HasValue && search.specIds.Contains(n.specId.Value));
            }

            return _mapper.Map<List<SpecValsDto>>(await query.OrderBy(n => n.index).ToListAsync());
        }
    }
}