#nullable disable
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Models;
using Common.Enumeraties;
using Common.Utilities;

namespace aspnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyHomeController : ControllerBase
    {
        private readonly IMediasService _mediasService;
        private readonly ITabsService _tabsService;
        private readonly ILogService _logService;

        public MyHomeController(IMediasService mediasService,
            ITabsService tabsService,
            ILogService logService)
        {
            _mediasService = mediasService;
            _tabsService = tabsService;
            _logService = logService;
        }

        [HttpPost("GetNavigation")]
        public async Task<ActionResult<Result<HomeNavigation>>> GetNavigation()
        {
            var result = new Result<HomeNavigation> { IsSucc  = true };
            try
            {
                var lstTab = await _tabsService.Search(new TabsSearch { type = (short)PageEnum.Home });
                var lstImg = await _mediasService.Search(new MediasSearch { tableType = (short)TableTypeEnum.None, mType = (short)MediaTypeEnum.Image, tableId = (long)PageEnum.Home });

                result.Data = new HomeNavigation
                {
                    swiper = lstImg.OrderBy(n => n.flag).Select(n => n.path).ToList(),
                    tabList = lstTab.Select(n => new TKey { text = n.text, key = n.key }).ToList(),
                    activityImg = "https://we-retail-static-1300977798.cos.ap-guangzhou.myqcloud.com/retail-mp/activity/banner.png"
                };
            }
            catch (Exception ex)
            {
                _logService.Increase(new LogDto { subject = "GetNavigation_Error", message = ex.Message.CutLength(300) });
                _logService.Increase(new LogDto { subject = "GetNavigation_Error", message = ex.StackTrace?.CutLength(300) });
            }

            return Ok(result);
        }
    }
}
