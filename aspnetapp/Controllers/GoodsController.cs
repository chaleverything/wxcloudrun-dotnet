#nullable disable
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Models;
using Common.Utilities;
using Common.Enumeraties;

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
            return await GetGoodsDetail(lstGoods, result);
        }

        [HttpPost("GetGoodsResult")]
        public async Task<ActionResult<ResultList<GoodsInfo>>> GetGoodsResult(GoodsSearch search)
        {
            var result = new ResultList<GoodsInfo> { IsSucc = true };
            search.isPutOnSale = true;
            search.available = true;
            (var lstGoods, var total) = await _goodsService.SearchResult(search);
            result.ReturnValue = new { Total = total };
            return await GetGoodsDetail(lstGoods, result);
        }

        public async Task<ActionResult<ResultList<GoodsInfo>>> GetGoodsDetail(List<GoodsDto> lstGoods, ResultList<GoodsInfo> result)
        {
            var lstGoodsId = lstGoods.Select(n => n.id).ToList();
            var lstImg = await _mediasService.Search(new MediasSearch { tableType = (short)TableTypeEnum.Goods, mType = (short)MediaTypeEnum.Image, tableIds = lstGoodsId });
            var lstSpec = await _specsService.Search(new SpecsSearch { goodsIds = lstGoodsId });
            var lstSpecId = lstSpec.Select(n => n.id).ToList();
            var lstSpecVal = await _specValsService.Search(new SpecValsSearch { specIds = lstSpecId });
            var lstSku = await _skusService.Search(new SkusSearch { goodsIds = lstGoodsId });

            var lstInfo = new List<GoodsInfo>();
            lstGoods.ForEach(g =>
            {
                var imgs = lstImg.Where(n => n.tableId == g.id).ToList();
                var specs = lstSpec.Where(n => n.goodsId == g.id).ToList();
                var skus = lstSku.Where(n => n.goodsId == g.id).ToList();

                _logService.Increase(new LogDto { subject = $"imgs_{g.id}", message = imgs.FirstOrDefault(n => n.flag == "1")?.path });

                var goodsInfo = new GoodsInfo
                {
                    saasId = g.saasId,
                    storeId = g.storeId,
                    spuId = g.spuId,
                    hitQuantity = g.hitQuantity,
                    title = g.title,
                    etitle = g.etitle,
                    tag = g.tag,
                    primaryImage = imgs.FirstOrDefault(n => n.flag == "1")?.path,
                    primaryImageContent = imgs.FirstOrDefault(n => n.flag == "1")?.content.BufferToBase64String(),
                    images = imgs.Where(n => n.flag == "2").Select(n => new CombMedias
                    {
                        Path = n.path,
                        Content = n.content.BufferToBase64String()
                    }).ToList(),
                    categoryIds = g.categoryIds,
                    specList = specs.Where(s => s.goodsId == g.id).Select(s => new SpecInfo
                    {
                        id = s.id,
                        title = s.title,
                        index = s.index,
                        specValueList = lstSpecVal.Where(sv => sv.specId == s.id).Select(sv => new SpecValInfo
                        {
                            id = sv.id,
                            specId = s.id,
                            saasId = sv.saasId,
                            value = sv.value,
                            index = sv.index,
                        }).OrderBy(sv => sv.index).ToList(),
                    }).OrderBy(s => s.index).ToList(),
                    skuList = skus.Where(s => s.goodsId == g.id).Select(s => new SkuInfo
                    {
                        id = s.id,
                        index = s.index,
                        specInfo = s.specInfo,
                        priceInfo = s.priceInfo,
                        stockInfo = s.stockInfo,
                        weight = s.weight,
                        volume = s.volume,
                        profitPrice = s.profitPrice
                    }).OrderBy(s => s.index).ToList(),

                    available = g.available,
                    minSalePrice = g.minSalePrice,
                    minLinePrice = g.minLinePrice,
                    maxSalePrice = g.maxSalePrice,
                    maxLinePrice = g.maxLinePrice,
                    stockQuantity = g.stockQuantity,
                    soldNum = g.soldNum,
                    isPutOnSale = g.isPutOnSale,
                    spuTagList = g.spuTagList,
                    limitInfo = g.limitInfo
                };

                lstInfo.Add(goodsInfo);
            });

            result.Data = lstInfo;

            return Ok(result);
        }
    }
}
