#nullable disable
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Models;
using Common.Utilities;

namespace aspnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly ICategorysService _categorysService;
        private readonly ILogService _logService;

        public CategorysController(ICategorysService categorysService, ILogService logService)
        {
            _categorysService = categorysService;
            _logService = logService;
        }

        [HttpPost("GetAllCategorys")]
        public async Task<ActionResult<ResultList<CategoryTree>>> GetAllCategorys()
        {
            var result = new ResultList<CategoryTree>();
            var lst = await _categorysService.GetAll();
            if (lst != null) 
            {
                result.IsSucc = true;
                var source = lst.Select(n => new CategoryTree { id = n.id, name = n.name, parentId = n.parentId, thumbnail = n.thumbnailPath, thumbnailPath = n.thumbnailPath, thumbnailContent = n.thumbnailContent }).ToList();
                result.Data = source.Where(n => !n.parentId.HasValue).ToList();
                result.Data.ForEach(m =>
                {
                    m.FillChildren(source);
                });
            }

            return Ok(result);
        }
    }
}
