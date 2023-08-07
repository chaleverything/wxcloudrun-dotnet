namespace Models
{
    public class KeywordHistorysSearch : SearchBase
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