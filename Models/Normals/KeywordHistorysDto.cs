namespace Models
{
    /// <summary>
    /// 关键字历史记录
    /// </summary>
    public class KeywordHistorysDto : DtoBase
    {
        /// <summary>
        /// OpenID
        /// 长度：50
        /// </summary>
        public string? openId { get; set; }
        /// <summary>
        /// UnionId
        /// 长度：50
        /// </summary>
        public string? unionId { get; set; }
        /// <summary>
        /// 关键字
        /// 长度：100
        /// </summary>
        public string? content { get; set; }
    }
}