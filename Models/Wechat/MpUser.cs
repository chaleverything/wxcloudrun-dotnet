namespace Models.Wechat
{
    public class MpUser
    {
        /// <summary>
        /// openid
        /// </summary>
        public string? openId { get; set; }

        /// <summary>
        /// nickName
        /// </summary>
        public string? nickName { get; set; }

        /// <summary>
        /// 性别 0：未知、1：男、2：女
        /// </summary>
        public int? gender { get; set; }

        /// <summary>
        /// city
        /// </summary>
        public string? city { get; set; }

        /// <summary>
        /// province
        /// </summary>
        public string? province { get; set; }

        /// <summary>
        /// country
        /// </summary>
        public string? country { get; set; }

        /// <summary>
        /// avatarUrl
        /// </summary>
        public string avatarUrl { get; set; }

        /// <summary>
        /// unionId
        /// </summary>
        public string? unionId { get; set; }

        /// <summary>
        /// 水印
        /// </summary>
        public MpWatermark? watermark { get; set; }
    }
}
