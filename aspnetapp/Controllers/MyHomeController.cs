﻿#nullable disable
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Models;
using Common.Enumeraties;

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
            _logService.Increase(new LogDto { subject = "GetNavigation", message = "A" });
            var lstImg = await _mediasService.Search(new MediasSearch { tableType = (short)TableTypeEnum.None, mType = (short)MediaTypeEnum.Image, tableId = (long)PageEnum.Home });
            _logService.Increase(new LogDto { subject = "GetNavigation", message = "B" });
            var lstTab = await _tabsService.Search(new TabsSearch { type = (short)PageEnum.Home });
            _logService.Increase(new LogDto { subject = "GetNavigation", message = "C" });

            result.Data = new HomeNavigation
            {
                swiper = lstImg.OrderBy(n => n.flag).Select(n => n.path).ToList(),
                tabList = lstTab.Select(n => new TKey { text = n.text, key = n.key }).ToList(),
                activityImg = "https://we-retail-static-1300977798.cos.ap-guangzhou.myqcloud.com/retail-mp/activity/banner.png"
            };

            return Ok(result);
        }
    }
}
