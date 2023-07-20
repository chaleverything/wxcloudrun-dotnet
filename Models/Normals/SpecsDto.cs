namespace Models
{
    /// <summary>
    /// 规格/型号
    /// </summary>
    public class SpecsDto : DtoBase
    {
        /// <summary>
        /// 商品ID
        /// 长度：20
        /// </summary>
        public long? goodsId { get; set; }
        /// <summary>
        /// 序号
        /// 长度：4
        /// </summary>
        public short? index { get; set; }
        /// <summary>
        /// 描述
        /// 长度：50
        /// </summary>
        public string? title { get; set; }
    }
}