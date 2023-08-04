using Models;

namespace Service.Interface
{
    public interface IUserService : IBaseService
    {
        void Increase(UserDto entity);
        Task<List<UserDto>> Search(UserSearch search);
        Task<UserDto> FindByOpenId(UserSearch search);
        Task<UserDto> FindByUnionId(UserSearch search);
    }
}
