using AutoMapper;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Service.Interface;

namespace Service.Instance
{
    public class CategorysService: ICategorysService
    {
        private readonly CategorysContext _context;
        private readonly IMapper _mapper;

        public CategorysService(CategorysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Increase(CategorysDto category)
        {
            category.creationTime = DateTime.Now;
            var entity = _mapper.Map<Categorys>(category);
            _context.Categorys.Add(entity);
            var unused = _context.SaveChanges();
        }

        public async Task<List<CategorysDto>> Search(CategorysSearch search)
        {
            var query = _context.Categorys.AsNoTracking().Where(n => !n.cancelTime.HasValue);
            if (search.parentId.HasValue)
            {
                query = query.Where(n => n.parentId == search.parentId);
            }
            if (!string.IsNullOrWhiteSpace(search.name))
            {
                query = query.Where(n => n.name != null && n.name.Contains(search.name));
            }

            return _mapper.Map<List<CategorysDto>>(await query.ToListAsync());
        }

        public async Task<List<CategorysDto>> GetAll()
        {
            var query = _context.Categorys.AsNoTracking().Where(n => !n.cancelTime.HasValue);
            return _mapper.Map<List<CategorysDto>>(await query.ToListAsync());
        }
    }
}