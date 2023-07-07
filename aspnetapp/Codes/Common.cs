using System.Text;

namespace aspnetapp.Codes
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public static class Common
    {
        public static string ConvertZh(this string content)
        {
            var bytes = Encoding.UTF8.GetBytes(content);
            return Encoding.Default.GetString(bytes);
        }
    }
}
