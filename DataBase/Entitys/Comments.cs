namespace DataBase.Entitys
{
    /// <summary>
    /// 评论
    /// </summary>
    public class Comments : EntityBase
    {
        /// <summary>
        /// 商品ID
        /// 长度：20
        /// </summary>
        public long? goodsId { get; set; }
        /// <summary>
        /// 库存单位ID
        /// 长度：20
        /// </summary>
        public long? skuId { get; set; }
        /// <summary>
        /// 产品单元ID
        /// 长度：25
        /// </summary>
        public string? spuId { get; set; }
        /// <summary>
        /// 内容
        /// 长度：4000
        /// </summary>
        public string? content { get; set; }
        /// <summary>
        /// 用户编号
        /// 长度：25
        /// </summary>
        public string? uCode { get; set; }
        /// <summary>
        /// 用户名称
        /// 长度：50
        /// </summary>
        public string? uName { get; set; }
        /// <summary>
        /// 是否匿名
        /// 长度：1
        /// </summary>
        public bool? isAnonymity { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime? commentTime { get; set; }
        /// <summary>
        /// 是否自动评论
        /// 长度：1
        /// </summary>
        public bool? isAutoComment { get; set; }
        /// <summary>
        /// 客服回复
        /// 长度：4000
        /// </summary>
        public string? sellerReply { get; set; }
        /// <summary>
        /// 商品详情
        /// 长度：200
        /// </summary>
        public string? goodsDetailInfo { get; set; }
        /// <summary>
        /// 作废时间
        /// </summary>
        public DateTime? cancelTime { get; set; }
    }
}
