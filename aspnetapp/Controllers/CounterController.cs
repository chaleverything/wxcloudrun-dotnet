#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web;
using aspnetapp.Codes;
using DataBase;
using Models;
using Service;

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
        private readonly CounterService _counterService;
        private readonly LogService _logService;

        public CounterController(CounterService counterService, LogService logService)
        {
            _counterService = counterService;
            _logService = logService;
        }

        // GET: api/count
        [HttpGet]
        public async Task<ActionResult<CounterResponse>> GetCounter()
        {
            var counter =  await _counterService.GetCounterWithInit();
            return new CounterResponse { data = counter.count };
        }

        // POST: api/Counter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CounterResponse>> PostCounter(CounterRequest data)
        {
            var counter = await _counterService.GetCounterWithInit();
            switch (data.action)
            {
                default:
                    return BadRequest();
                case "inc":
                    counter = await _counterService.Increase();
                    return new CounterResponse { data = counter.count };
                case "clear":
                    counter = await _counterService.Increase();
                    return new CounterResponse { data = counter.count };
                case "hello":
                    _logService.Increase(new Log { subject = "转码日志", message = "哈喽！世界".EncodeBase64() });
                    return new CounterResponse { msg = "哈喽！世界".EncodeBase64() };
                case "hello2":
                    return new CounterResponse { msg = HttpUtility.UrlEncode( "哈喽！世界".EncodeBase64()) };
            }
        }
    }
}
