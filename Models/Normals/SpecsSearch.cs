namespace Models
{
    public class SpecsSearch : SearchBase
    {
        /// <summary>
        /// 商品ID集合
        /// </summary>
        public List<long>? goodsIds { get; set; }
        /// <summary>
        /// 描述
        /// 长度：50
        /// </summary>
        public string? title { get; set; }
    }
}