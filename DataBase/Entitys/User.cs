namespace DataBase.Entitys
{
    /// <summary>
    /// 用户
    /// </summary>
    public class User : EntityBase
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
        /// 名称
        /// 长度：120
        /// </summary>
        public string? name { get; set; }
        /// <summary>
        /// 昵称
        /// 长度：120
        /// </summary>
        public string? nickName { get; set; }
        /// <summary>
        /// 性别
        /// 长度：4
        /// </summary>
        public short? gender { get; set; }
        /// <summary>
        /// 市
        /// 长度：30
        /// </summary>
        public string? city { get; set; }
        /// <summary>
        /// 省
        /// 长度：30
        /// </summary>
        public string? province { get; set; }
        /// <summary>
        /// 邦
        /// 长度：30
        /// </summary>
        public string? country { get; set; }
        /// <summary>
        /// 状态
        /// 长度：4
        /// </summary>
        public short? status { get; set; }
    }
}
