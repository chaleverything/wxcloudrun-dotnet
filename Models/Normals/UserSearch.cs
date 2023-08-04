namespace Models
{
    public class UserSearch : SearchBase
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
        /// 状态
        /// 长度：4
        /// </summary>
        public short? status { get; set; }
    }
}