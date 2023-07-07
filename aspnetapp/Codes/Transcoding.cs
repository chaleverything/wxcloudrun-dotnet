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
        /// <param name="code_type">UTF-8、Unicode、GB2312、GB18030</param>
        /// <returns></returns>
        public static (string, string) EncodeBase64(this string code, string code_type = "UTF-8")
        {
            string encode = string.Empty;
            string err = string.Empty;
            try
            {
                byte[] bytes = Encoding.GetEncoding(code_type).GetBytes(code);
                encode = Convert.ToBase64String(bytes);
                encode = encode.Replace("+", "[");
                encode = encode.Replace("/", "]");
            }
            catch (Exception ex)
            {
                encode = code;
                err = ex.Message;
            }
            
            return (encode, err);
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="code"></param>
        /// <param name="code_type">UTF-8、Unicode、GB2312、GB18030</param>
        /// <returns></returns>
        public static (string, string) DecodeBase64(this string code, string code_type = "UTF-8")
        {
            string decode = string.Empty;
            string err = string.Empty;
            int num = 0;
            if (string.IsNullOrWhiteSpace(code))
            {
                goto end;
            }
            else if (code.Length < 4 || int.TryParse(code, out num))
            {
                return (code, err);
            }

            code = code.Replace("[", "+");
            code = code.Replace("]", "/");
            try
            {
                byte[] bytes = Convert.FromBase64String(code);
                decode = Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch (Exception ex)
            {
                decode = code;
                err = ex.Message;
            }
            decode = decode.Replace("\0", "");

            end:
            return (decode, err);
        }
    }
}
