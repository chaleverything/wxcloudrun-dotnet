using Models;

namespace Service.Interface
{
    public interface IMediasService : IBaseService
    {
        void Increase(MediasDto entity);
        Task<List<MediasDto>> Search(MediasSearch search);
    }
}
