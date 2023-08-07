#nullable disable
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Models;
using aspnetapp.Codes;

namespace aspnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsService _goodsService;
        private readonly IMediasService _mediasService;
        private readonly ISpecsService _specsService;
        private readonly ISpecValsService _specValsService;
        private readonly ISkusService _skusService;
        private readonly ILogService _logService;

        public GoodsController(IGoodsService goodsService,
            IMediasService mediasService,
            ISpecsService specsService,
            ISpecValsService specValsService,
            ISkusService skusService,
            ILogService logService)
        {
            _goodsService = goodsService;
            _mediasService = mediasService;
            _specsService = specsService;
            _specValsService = specValsService;
            _skusService = skusService;
            _logService = logService;
        }

        [HttpPost("GetGoodsInfo")]
        public async Task<ActionResult<ResultList<GoodsInfo>>> GetGoodsInfo(GoodsSearch search)
        {
            var result = new ResultList<GoodsInfo> { IsSucc = true };
            search.isPutOnSale = true;
            search.available = true;
            (var lstGoods, var total) = await _goodsService.Search(search);
            result.ReturnValue = new { Total = total };
            var controllerExtends = new ControllerExtends(_goodsService, _mediasService, _specsService, _specValsService, _skusService, _logService);
            return await controllerExtends.GetGoodsDetail(lstGoods, result);
        }

        [HttpPost("GetGoodsResult")]
        public async Task<ActionResult<ResultList<GoodsInfo>>> GetGoodsResult(GoodsSearch search)
        {
            var result = new ResultList<GoodsInfo> { IsSucc = true };
            search.isPutOnSale = true;
            search.available = true;
            (var lstGoods, var total) = await _goodsService.SearchResult(search);
            result.ReturnValue = new { Total = total };
            var controllerExtends = new ControllerExtends(_goodsService, _mediasService, _specsService, _specValsService, _skusService, _logService);
            return await controllerExtends.GetGoodsDetail(lstGoods, result);
        }

    }
}
