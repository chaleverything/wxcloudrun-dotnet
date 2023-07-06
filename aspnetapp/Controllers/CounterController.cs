#nullable disable
using Microsoft.AspNetCore.Mvc;
using System.Web;
using aspnetapp.Codes;
using Models;
using Service.Instance;
using Service.Interface;

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
        private readonly ICounterService _counterService;
        private readonly ILogService _logService;

        public CounterController(ICounterService counterService, ILogService logService)
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
            //_logService.Increase(new Log { subject = "MYSQL_USERNAME", message = Environment.GetEnvironmentVariable("MYSQL_USERNAME") });
            //_logService.Increase(new Log { subject = "MYSQL_PASSWORD", message = Environment.GetEnvironmentVariable("MYSQL_PASSWORD") });
            //_logService.Increase(new Log { subject = "MYSQL_ADDRESS", message = Environment.GetEnvironmentVariable("MYSQL_ADDRESS") });
            var counter = await _counterService.GetCounterWithInit();
            var content = "哈喽！世界";
            var result = string.Empty;
            var err = string.Empty;
            switch (data.action)
            {
                default:
                    return BadRequest();
                case "inc":
                    counter = await _counterService.Increase();
                    return new CounterResponse { data = counter.count };
                case "clear":
                    counter = await _counterService.Clear();
                    return new CounterResponse { data = counter.count };
                case "hello":
                    //_logService.Increase(new Log { subject = "转码日志UTF-8", message = "哈喽！世界".EncodeBase64("GB2312") });
                    (result, err) = content.EncodeBase64("GB18030");
                    if(!string.IsNullOrWhiteSpace(err))
                    {
                        _logService.Increase(new Log { subject = "转码日志GB18030", message = err });
                    }
                    return new CounterResponse { msg = result };
                case "hello2":
                    (result, err) = content.EncodeBase64("GB2312");
                    if (!string.IsNullOrWhiteSpace(err))
                    {
                        _logService.Increase(new Log { subject = "转码日志GB2312", message = err });
                    }
                    return new CounterResponse { msg = result };
                case "hello3":
                    (result, err) = content.EncodeBase64("Unicode");
                    if (!string.IsNullOrWhiteSpace(err))
                    {
                        _logService.Increase(new Log { subject = "转码日志Unicode", message = err });
                    }
                    return new CounterResponse { msg = result };
            }
        }
    }
}
