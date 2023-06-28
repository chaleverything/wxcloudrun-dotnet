#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnetapp;
using Microsoft.AspNetCore.WebUtilities;
using System.Web;

public class CounterRequest {
    public string action { get; set; }
}
public class CounterResponse {
    public int data { get; set; }
    public string msg { get; set; }
}

namespace aspnetapp.Controllers
{
    [Route("api/count")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        private readonly CounterContext _context;

        public CounterController(CounterContext context)
        {
            _context = context;
        }
        private async Task<Counter> getCounterWithInit()
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
        // GET: api/count
        [HttpGet]
        public async Task<ActionResult<CounterResponse>> GetCounter()
        {
            var counter =  await getCounterWithInit();
            return new CounterResponse { data = counter.count };
        }

        // POST: api/Counter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CounterResponse>> PostCounter(CounterRequest data)
        {
            //if (data.action == "inc") {
            //    var counter = await getCounterWithInit();
            //    counter.count += 1;
            //    counter.updatedAt = DateTime.Now;
            //    await _context.SaveChangesAsync();
            //    return new CounterResponse { data = counter.count };
            //}
            //else if (data.action == "clear") {
            //    var counter = await getCounterWithInit();
            //    counter.count = 0;
            //    counter.updatedAt = DateTime.Now;
            //    await _context.SaveChangesAsync();
            //    return new CounterResponse { data = counter.count };
            //}
            //else {
            //    return BadRequest();
            //}
            var counter = await getCounterWithInit();
            switch (data.action)
            {
                default:
                    return BadRequest();
                case "inc":
                    counter.count += 1;
                    counter.updatedAt = DateTime.Now;
                    await _context.SaveChangesAsync();
                    return new CounterResponse { data = counter.count };
                case "clear":
                    counter.count = 0;
                    counter.updatedAt = DateTime.Now;
                    await _context.SaveChangesAsync();
                    return new CounterResponse { data = counter.count };
                case "hello":
                    return new CounterResponse { msg = "哈喽！世界" };
                case "hello1":
                    return new CounterResponse { msg = HttpUtility.HtmlEncode("哈喽！世界") };
                case "hello2":
                    return new CounterResponse { msg = HttpUtility.UrlEncode("哈喽！世界") };
            }
        }
    }
}
