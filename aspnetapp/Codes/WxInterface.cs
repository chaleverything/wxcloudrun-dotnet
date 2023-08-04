using Common.Utilities;
using Models.Wechat;        

namespace aspnetapp.Codes
{
    public static class WxInterface
    {
        /// <summary>
        /// 通过Code获取小程序用户信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="miniProgramType"></param>
        /// <returns></returns>
        public static MpUserSession? GetAppUser(this string code)
        {
            var appId = Environment.GetEnvironmentVariable("MINI_APPID");
            var appSecret = Environment.GetEnvironmentVariable("MINI_APPSECRET");

#if DEBUG
            appId = Constant.Mini_AppId;
            appId = Constant.Mini_AppSecret;
#endif

            return WebApiHelper.GetAsync<MpUserSession>(string.Format(Constant.WxUri_UserSession, appId, appSecret, code));
        }
    }
}
