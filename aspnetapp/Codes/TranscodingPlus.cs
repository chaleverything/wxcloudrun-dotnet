using PeterO.Text;

namespace aspnetapp.Codes
{
    /// <summary>
    /// 转码
    /// </summary>
    public static class TranscodingPlus
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static (string, string) EncodeBase64Plus(this string code)
        {
            string encode = string.Empty;
            string err = string.Empty;
            if (string.IsNullOrWhiteSpace(code))
            {
                goto end;
            }

            try
            {
                encode = Convert.ToBase64String(Encodings.EncodeToBytes(code, Encodings.UTF8));
            }
            catch (Exception ex)
            {
                encode = code;
                err = ex.Message;
            }

            end:
            return (encode, err);
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static (string, string) DecodeBase64Plus(this string code)
        {
            string decode = string.Empty;
            string err = string.Empty;
            if (string.IsNullOrWhiteSpace(code))
            {
                goto end;
            }

            try
            {
                decode = Encodings.DecodeToString(Encodings.UTF8, Convert.FromBase64String(code));
            }
            catch (Exception ex)
            {
                decode = code;
                err = ex.Message;
            }

            end:
            return (decode, err);
        }
    }
}
