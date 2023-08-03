namespace DataBase.Entitys
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Goods : EntityBase
    {
        /// <summary>
        /// 软件服务ID
        /// 长度：25
        /// </summary>
        public string? saasId { get; set; }
        /// <summary>
        /// 仓库ID
        /// 长度：20
        /// </summary>
        public long? storeId { get; set; }
        /// <summary>
        /// 产品单元ID
        /// 长度：25
        /// </summary>
        public string? spuId { get; set; }
        /// <summary>
        /// 点击数
        /// 长度：20
        /// </summary>
        public long? hitQuantity { get; set; }
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
        /// 标签
        /// 长度：100
        /// </summary>
        public string? tag { get; set; }
        /// <summary>
        /// 类别ID集合
        /// 长度：200
        /// </summary>
        public string? categoryIds { get; set; }
        /// <summary>
        /// 是否启用
        /// 长度：1
        /// </summary>
        public bool? available { get; set; }
        /// <summary>
        /// 最低销售价格
        /// 长度：11
        /// </summary>
        public float? minSalePrice { get; set; }
        /// <summary>
        /// 最低价格线
        /// 长度：11
        /// </summary>
        public float? minLinePrice { get; set; }
        /// <summary>
        /// 最高销售价格
        /// 长度：11
        /// </summary>
        public float? maxSalePrice { get; set; }
        /// <summary>
        /// 最高价格线
        /// 长度：11
        /// </summary>
        public float? maxLinePrice { get; set; }
        /// <summary>
        /// 库存数量
        /// 长度：11
        /// </summary>
        public int? stockQuantity { get; set; }
        /// <summary>
        /// 已销售数量
        /// 长度：11
        /// </summary>
        public int? soldNum { get; set; }
        /// <summary>
        /// 是否在线销售
        /// 长度：1
        /// </summary>
        public bool? isPutOnSale { get; set; }
        /// <summary>
        /// 产品单元标签集合
        /// 长度：500
        /// </summary>
        public string? spuTagList { get; set; }
        /// <summary>
        /// 限购信息
        /// 长度：300
        /// </summary>
        public string? limitInfo { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? updateTime { get; set; }
        /// <summary>
        /// 更新人
        /// 长度：15
        /// </summary>
        public string? updateBy { get; set; }
        /// <summary>
        /// 作废时间
        /// </summary>
        public DateTime? cancelTime { get; set; }
    }
}
