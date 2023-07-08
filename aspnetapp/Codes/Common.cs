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

        public static string ConvertBytes(this string content)
        {
            var result = string.Empty;
            var bytes = Encoding.UTF8.GetBytes(content);
            result += "UTF8:" + string.Join(",", bytes) + "||";
            bytes = Encoding.Default.GetBytes(content);
            result += "Default:" + string.Join(",", bytes) + "||";
            bytes = Encoding.BigEndianUnicode.GetBytes(content);
            result += "BigEndianUnicode:" + string.Join(",", bytes) + "||";
            bytes = Encoding.ASCII.GetBytes(content);
            result += "ASCII:" + string.Join(",", bytes) + "||";
            bytes = Encoding.Latin1.GetBytes(content);
            result += "Latin1:" + string.Join(",", bytes) + "||";
            bytes = Encoding.Unicode.GetBytes(content);
            result += "Unicode:" + string.Join(",", bytes) + "||";
            bytes = Encoding.UTF32.GetBytes(content);
            result += "UTF32:" + string.Join(",", bytes) + "||";
            bytes = Encoding.UTF7.GetBytes(content);
            result += "UTF7:" + string.Join(",", bytes);

            return result;
        }

        public static string ConvertDef(this string content)
        {
            var bytes = Encoding.UTF8.GetBytes(content);
            return Encoding.Default.GetString(bytes);
        }
    }
}
