namespace Models
{
    public class GoodsSearch : SearchBase
    {
        /// <summary>
        /// 仓库ID集合
        /// </summary>
        public List<long>? lstStoreId { get; set; }
        /// <summary>
        /// 主题
        /// 长度：250
        /// </summary>
        public string? title { get; set; }
        /// <summary>
        /// E主题
        /// 长度：250
        /// </summary>
        public string? etitle { get; set; }
        /// <summary>
        /// 类别ID集合
        /// </summary>
        public string? categoryIds { get; set; }
        /// <summary>
        /// 是否启用
        /// 长度：1
        /// </summary>
        public bool? available { get; set; }
        /// <summary>
        /// 是否在线销售
        /// 长度：1
        /// </summary>
        public bool? isPutOnSale { get; set; }
    }
}