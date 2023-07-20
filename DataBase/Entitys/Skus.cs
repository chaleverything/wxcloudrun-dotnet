namespace DataBase.Entitys
{
    /// <summary>
    /// 库存单位
    /// </summary>
    public class Skus : EntityBase
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
        /// 规格/型号信息
        /// 长度：2000
        /// </summary>
        public string? specInfo { get; set; }
        /// <summary>
        /// 价格信息
        /// 长度：2000
        /// </summary>
        public string? priceInfo { get; set; }
        /// <summary>
        /// 库存信息
        /// 长度：2000
        /// </summary>
        public string? stockInfo { get; set; }
        /// <summary>
        /// 重量
        /// 长度：120
        /// </summary>
        public string? weight { get; set; }
        /// <summary>
        /// 体积
        /// 长度：120
        /// </summary>
        public string? volume { get; set; }
        /// <summary>
        /// 利润价格
        /// 长度：120
        /// </summary>
        public string? profitPrice { get; set; }
    }
}
