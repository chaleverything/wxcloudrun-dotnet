using AutoMapper;
using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models;
using Service.Interface;

namespace Service.Instance
{
    public class LogService: ILogService
    {
        private readonly LogContext _context;
        private readonly IMapper _mapper;

        public LogService(LogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Increase(LogDto log)
        {
            log.creationTime = DateTime.Now;
            var entity = _mapper.Map<Log>(log);
            _context.Log.Add(entity);
            var unused = _context.SaveChanges();
        }

        public async Task<List<LogDto>> Search(LogSearch search)
        {
            var query = _context.Log.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(search.subject))
            {
                query = query.Where(n => n.subject != null && n.subject.Contains(search.subject));
            }
            if (!string.IsNullOrWhiteSpace(search.message))
            {
                query = query.Where(n => n.message != null && n.message.Contains(search.message));
            }
            if (search.startTime.HasValue)
            {
                query = query.Where(n => n.creationTime >= search.startTime);
            }
            if (search.endTime.HasValue)
            {
                query = query.Where(n => n.creationTime <= search.endTime);
            }

            return _mapper.Map<List<LogDto>>(await query.ToListAsync());
        }
    }
}