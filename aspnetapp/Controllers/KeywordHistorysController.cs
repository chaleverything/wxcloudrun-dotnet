#nullable disable
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Models;
using aspnetapp.Codes;
using Common.Utilities;
using Common.Enumeraties;
using Service.Instance;

namespace aspnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeywordHistorysController : ControllerBase
    {
        private readonly IKeywordHistorysService _keywordHistorysService;
        private readonly IUserService _userService;
        private readonly ILogService _logService;

        public KeywordHistorysController(IKeywordHistorysService keywordHistorysService, IUserService userService, ILogService logService)
        {
            _keywordHistorysService = keywordHistorysService;
            _userService = userService;
            _logService = logService;
        }

        [HttpPost("IncreaseKeywordHistorys")]
        public async Task<ActionResult<Result>> IncreaseKeywordHistorysByOpenId(KeywordHistorysDto keywordHistory)
        {
            var result = new Result { IsSucc = true };
            if(string.IsNullOrWhiteSpace(keywordHistory.openId) || string.IsNullOrWhiteSpace(keywordHistory.content))
            {
                goto end;
            }

            var user = await _userService.FindByOpenId(new UserSearch { openId = keywordHistory.openId });
            if (user == null) 
            {
                goto end;
            }

            _keywordHistorysService.Increase(new KeywordHistorysDto { openId = keywordHistory.openId, content = keywordHistory.content, creationTime = DateTime.Now });

            end:
            return Ok(result);
        }

        [HttpPost("ClearKeywordHistorysByOpenId")]
        public ActionResult<Result> ClearKeywordHistorysByOpenId(KeywordHistorysSearch search)
        {
            var result = new Result { IsSucc = true };
            _keywordHistorysService.RemoveByOpenId(search);
            return Ok(result);
        }

        [HttpPost("ClearKeywordHistorysByUnionId")]
        public ActionResult<Result> ClearKeywordHistorysByUnionId(KeywordHistorysSearch search)
        {
            var result = new Result { IsSucc = true };
            _keywordHistorysService.RemoveByUnionId(search);
            return Ok(result);
        }

        [HttpPost("GetKeywordHistorysByOpenId")]
        public async Task<ActionResult<Result<List<KeywordHistorysDto>>>> GetKeywordHistorysByOpenId(KeywordHistorysSearch search)
        {
            var result = new Result<List<KeywordHistorysDto>> { IsSucc = true };
            result.Data = await _keywordHistorysService.FindByOpenId(search);
            return Ok(result);
        }

        [HttpPost("GetKeywordHistorysByUnionId")]
        public async Task<ActionResult<Result<List<KeywordHistorysDto>>>> GetKeywordHistorysByUnionId(KeywordHistorysSearch search)
        {
            var result = new Result<List<KeywordHistorysDto>> { IsSucc = true };
            result.Data = await _keywordHistorysService.FindByUnionId(search);
            return Ok(result);
        }

    }
}
