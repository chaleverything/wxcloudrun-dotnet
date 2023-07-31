using AutoMapper;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Service.Interface;

namespace Service.Instance
{
    public class MediasService: IMediasService
    {
        private readonly MediasContext _context;
        private readonly IMapper _mapper;

        public MediasService(MediasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Increase(MediasDto dto)
        {
            dto.creationTime = DateTime.Now;
            var entity = _mapper.Map<Medias>(dto);
            _context.Medias.Add(entity);
            var unused = _context.SaveChanges();
        }

        public async Task<List<MediasDto>> Search(MediasSearch search)
        {
            var query = _context.Medias.AsNoTracking();
            if (search.tableType.HasValue)
            {
                query = query.Where(n => n.tableType == search.tableType);
            }
            if (search.mType.HasValue)
            {
                query = query.Where(n => n.mType == search.mType);
            }
            if (search.tableId.HasValue)
            {
                query = query.Where(n => n.tableId == search.tableId);
            }
            if(search.tableIds?.Count > 0)
            {
                query = query.Where(n => n.tableId.HasValue && search.tableIds.Contains(n.tableId.Value));
            }
            if (!string.IsNullOrWhiteSpace(search.flag))
            {
                query = query.Where(n => n.flag == search.flag);
            }

            return _mapper.Map<List<MediasDto>>(await query.ToListAsync());
        }
    }
}