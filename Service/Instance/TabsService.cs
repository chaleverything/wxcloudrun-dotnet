using AutoMapper;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Service.Interface;

namespace Service.Instance
{
    public class TabsService: ITabsService
    {
        private readonly TabsContext _context;
        private readonly IMapper _mapper;

        public TabsService(TabsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Increase(TabsDto dto)
        {
            dto.creationTime = DateTime.Now;
            var entity = _mapper.Map<Tabs>(dto);
            _context.Tabs.Add(entity);
            var unused = _context.SaveChanges();
        }

        public async Task<List<TabsDto>> Search(TabsSearch search)
        {
            var query = _context.Tabs.AsNoTracking().Where(n => !n.cancelTime.HasValue);
            if (search.type.HasValue)
            {
                query = query.Where(n => n.type == search.type);
            }

            return _mapper.Map<List<TabsDto>>(await query.OrderBy(n => n.key).ToListAsync());
        }
    }
}