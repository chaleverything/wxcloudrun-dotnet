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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogService _logService;

        public UserController(IUserService userService, ILogService logService)
        {
            _userService = userService;
            _logService = logService;
        }

        [HttpPost("GetUserInfo")]
        public async Task<ActionResult<Result<UserDto>>> GetUserInfo(UserSearch search)
        {
            var result = new Result<UserDto> { IsSucc = true };
            result.Data = await _userService.FindByOpenId(search);
            return Ok(result);
        }


        [HttpPost("GetUserInfoByCode")]
        public async Task<ActionResult<Result<UserDto>>> GetUserInfoByCode(TKey key)
        {
            var result = new Result<UserDto> { IsSucc = true };

            _logService.Increase(new LogDto { subject = "User", message = key.code });

            var appUser =  key.code.GetAppUser();

            _logService.Increase(new LogDto { subject = "User", message = appUser?.openId });
            if (string.IsNullOrWhiteSpace(appUser?.openId))
            {
                goto end;
            }

            result.Data = await _userService.FindByOpenId(new UserSearch { openId = appUser.openId });
            if(result.Data == null)
            {
                var user = new UserDto();
                appUser.AutoCopyFields(user);

                user.status = (short)UserStatusEnum.Normal;
                user.creationTime = DateTime.Now;

                _userService.Increase(user);

                result.Data = user;
            }

            end:
            return Ok(result);
        }
    }
}
