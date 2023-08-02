#nullable disable
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Models;
using Common.Utilities;
using Common.Enumeraties;
using Service.Instance;
using System.Diagnostics;

namespace aspnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMediasService _mediasService;
        private readonly ITabsService _tabsService;
        private readonly ILogService _logService;

        public HomeController(IMediasService mediasService,
            ITabsService tabsService,
            ILogService logService)
        {
            _mediasService = mediasService;
            _tabsService = tabsService;
            _logService = logService;
        }

        [HttpPost("GetNavigation")]
        public async Task<ActionResult<Result<dynamic>>> GetNavigation()
        {
            var result = new Result<dynamic> { IsSucc  = true };
            var lstImg = await _mediasService.Search(new MediasSearch { tableType = (short)TableTypeEnum.None, mType = (short)MediaTypeEnum.Image, tableId = (long)PageEnum.Home });
            var lstTab = await _tabsService.Search(new TabsSearch { type = (short)PageEnum.Home });

            result.Data = new
            {
                swiper = lstImg.OrderBy(n => n.flag).Select(n => n.path).ToArray(),
                tabList = lstTab.Select(n => new { n.text, n.key }).ToList(),
                activityImg = "https://we-retail-static-1300977798.cos.ap-guangzhou.myqcloud.com/retail-mp/activity/banner.png"
            };

            return Ok(result);
        }
    }
}
