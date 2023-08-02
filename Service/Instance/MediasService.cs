using AutoMapper;
using Common.Utilities;
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
        private readonly ILogService _logService;

        public MediasService(MediasContext context, IMapper mapper, ILogService logService)
        {
            _context = context;
            _mapper = mapper;
            _logService = logService;
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
            try
            {
                var query = _context.Medias.AsNoTracking();

                _logService.Increase(new LogDto { subject = "Medias Search", message = "1"});
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
                if (search.tableIds?.Count > 0)
                {
                    query = query.Where(n => n.tableId.HasValue && search.tableIds.Contains(n.tableId.Value));
                }
                if (!string.IsNullOrWhiteSpace(search.flag))
                {
                    query = query.Where(n => n.flag == search.flag);
                }
                _logService.Increase(new LogDto { subject = "Medias Search", message = "2" });
                return _mapper.Map<List<MediasDto>>(await query.ToListAsync());
            }
            catch(Exception ex)
            {
                _logService.Increase(new LogDto { subject = "Medias Search", message = ex.Message.CutLength(300) });
                _logService.Increase(new LogDto { subject = "Medias Search", message = ex.StackTrace?.CutLength(500) });
                throw new Exception(ex.Message);
            }
        }
    }
}