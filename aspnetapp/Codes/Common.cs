using System.Text;
using System.Text.Json;

namespace aspnetapp.Codes
{
    /// <summary>
    /// 帮助类
    /// </summary>
    public static class Common
    {
        public static string ConvertZh(this string content)
        {
            //var bytes = Encoding.Default.GetBytes(content);
            //return Encoding.UTF8.GetString(bytes);


            byte[] utf8Bytes = Encoding.UTF8.GetBytes(content);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string decodedString = Encoding.UTF8.GetString(utf8Bytes);
            string encodedString = JsonSerializer.Serialize(decodedString, options);

            return encodedString;
        }

        public static string ConvertDef(this string content)
        {
            var bytes = Encoding.UTF8.GetBytes(content);
            return Encoding.Default.GetString(bytes);
        }
    }
}
