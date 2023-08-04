using AutoMapper;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Service.Interface;

namespace Service.Instance
{
    public class UserService: IUserService
    {
        private readonly UserContext _context;
        private readonly IMapper _mapper;

        public UserService(UserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Increase(UserDto dto)
        {
            dto.creationTime = DateTime.Now;
            var entity = _mapper.Map<User>(dto);
            _context.User.Add(entity);
            var unused = _context.SaveChanges();
        }

        public async Task<List<UserDto>> Search(UserSearch search)
        {
            var query = _context.User.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(search.name))
            {
                query = query.Where(n => (n.name != null && n.name.Contains(search.name)) || (n.nickName != null && n.nickName.Contains(search.name)));
            }

            return _mapper.Map<List<UserDto>>(await query.OrderByDescending(n => n.creationTime).ToListAsync());
        }

        public async Task<UserDto> FindByOpenId(UserSearch search)
        {
            var query = _context.User.AsNoTracking().Where(n=> n.openId == search.openId);
            return _mapper.Map<UserDto>(await query.FirstOrDefaultAsync());
        }

        public async Task<UserDto> FindByUnionId(UserSearch search)
        {
            var query = _context.User.AsNoTracking().Where(n => n.unionId == search.unionId);
            return _mapper.Map<UserDto>(await query.FirstOrDefaultAsync());
        }
    }
}