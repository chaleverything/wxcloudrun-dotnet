#nullable disable
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Models;
using aspnetapp.Codes;
using Common.Utilities;
using Common.Enumeraties;
using Service.Instance;
using Newtonsoft.Json;

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

        [HttpPost("IncreaseKeywordHistorysByOpenId")]
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

            //判断是否已经存在该关键字历史记录
            var keyword = await _keywordHistorysService.FindContentByOpenId(new KeywordHistorysSearch { openId = keywordHistory.openId, content = keywordHistory.content });
            if (keyword != null) 
            {
                goto end;
            }

            _keywordHistorysService.Increase(new KeywordHistorysDto { openId = keywordHistory.openId, content = keywordHistory.content, creationTime = DateTime.Now });

            end:
            return Ok(result);
        }

        [HttpPost("IncreaseKeywordHistorysByUnionId(")]
        public async Task<ActionResult<Result>> IncreaseKeywordHistorysByUnionId(KeywordHistorysDto keywordHistory)
        {
            var result = new Result { IsSucc = true };
            if (string.IsNullOrWhiteSpace(keywordHistory.unionId) || string.IsNullOrWhiteSpace(keywordHistory.content))
            {
                goto end;
            }

            var user = await _userService.FindByUnionId(new UserSearch { unionId = keywordHistory.unionId });
            if (user == null)
            {
                goto end;
            }

            //判断是否已经存在该关键字历史记录
            var keyword = await _keywordHistorysService.FindContentByUnionId(new KeywordHistorysSearch { unionId = keywordHistory.unionId, content = keywordHistory.content });
            if (keyword != null)
            {
                goto end;
            }

            _keywordHistorysService.Increase(new KeywordHistorysDto { unionId = keywordHistory.unionId, content = keywordHistory.content, creationTime = DateTime.Now });

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
        public async Task<ActionResult<Result<List<string>>>> GetKeywordHistorysByOpenId(KeywordHistorysSearch search)
        {
            var result = new Result<List<string>> { IsSucc = true };
            var lst = await _keywordHistorysService.FindByOpenId(search);
            result.Data = lst?.Select(n => n.content).ToList();
            return Ok(result);
        }

        [HttpPost("GetKeywordHistorysByUnionId")]
        public async Task<ActionResult<Result<List<string>>>> GetKeywordHistorysByUnionId(KeywordHistorysSearch search)
        {
            var result = new Result<List<string>> { IsSucc = true };
            var lst = await _keywordHistorysService.FindByUnionId(search);
            result.Data = lst?.Select(n => n.content).ToList();
            return Ok(result);
        }

        [HttpPost("GetPopulars")]
        public async Task<ActionResult<Result<List<string>>>> GetPopulars(KeywordHistorysSearch search)
        {
            var result = new Result<List<string>> { IsSucc = true };
            var lst = await _keywordHistorysService.GetPopulars(search);
            result.Data = lst?.Select(n => n.content).ToList();
            return Ok(result);
        }

    }
}
