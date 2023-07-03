using DataBase;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Service
{
    public class CounterService
    {
        private readonly CounterContext _context;
        public CounterService(CounterContext context)
        {
            _context = context;
        }

        public async Task<Counter> GetCounterWithInit()
        {
            var counters = await _context.Counters.ToListAsync();
            if (counters.Count() > 0)
            {
                return counters[0];
            }
            else
            {
                var counter = new Counter { count = 0, createdAt = DateTime.Now, updatedAt = DateTime.Now };
                _context.Counters.Add(counter);
                await _context.SaveChangesAsync();
                return counter;
            }
        }

        public async Task<Counter> Increase()
        {
            var entity = await _context.Counters.FirstOrDefaultAsync();
            if (entity != null)
            {
                entity.count += 1;
                entity.updatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return entity ?? new Counter { count = 0, createdAt = DateTime.Now, updatedAt = DateTime.Now };
        }

        public async Task<Counter> Clear()
        {
            var entity = await _context.Counters.FirstOrDefaultAsync();
            if (entity != null)
            {
                entity.count = 0;
                entity.updatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return entity ?? new Counter { count = 0, createdAt = DateTime.Now, updatedAt = DateTime.Now };
        }
    }
}