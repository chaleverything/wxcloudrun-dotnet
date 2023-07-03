using DataBase;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Service
{
    public class LogService
    {
        private readonly LogContext _context;
        public LogService(LogContext context)
        {
            _context = context;
        }

        public void Increase(Log entity)
        {
            entity.creationTime = DateTime.Now;
            _context.Log.Add(entity);
        }

        public async Task<List<Log>> Search(LogSearch search)
        {
            var query = _context.Log.AsNoTracking();
            if(!string.IsNullOrWhiteSpace(search.subject))
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

            return await query.ToListAsync();
        }
    }
}