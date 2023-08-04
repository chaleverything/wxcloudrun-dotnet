namespace Models.Wechat
{
    /// <summary>
    /// 小程序用户手机水印
    /// </summary>
    public class MpWatermark
    {
        /// <summary>
        /// appid
        /// </summary>
        public string? appid { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long? timestamp { get; set; }
    }
}
