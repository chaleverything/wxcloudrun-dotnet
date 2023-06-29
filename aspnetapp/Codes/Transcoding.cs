using System.Text;

namespace aspnetapp.Codes
{
    /// <summary>
    /// 转码
    /// </summary>
    public static class Transcoding
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="code"></param>
        /// <param name="code_type">UTF-8、Unicode</param>
        /// <returns></returns>
        public static string EncodeBase64(this string code, string code_type = "UTF-8")
        {
            string encode = "";
            byte[] bytes = Encoding.GetEncoding(code_type).GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            encode = encode.Replace("+", "[");
            encode = encode.Replace("/", "]");
            return encode;
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="code"></param>
        /// <param name="code_type">UTF-8、Unicode</param>
        /// <returns></returns>
        public static string DecodeBase64(this string code, string code_type = "UTF-8")
        {
            int num = 0;
            if (string.IsNullOrWhiteSpace(code))
            {
                return "";
            }
            else if (code.Length < 4 || int.TryParse(code, out num))
            {
                return code;
            }

            string decode = "";
            code = code.Replace("[", "+");
            code = code.Replace("]", "/");
            try
            {
                byte[] bytes = Convert.FromBase64String(code);
                decode = Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            decode = decode.Replace("\0", "");
            return decode;
        }
    }
}
