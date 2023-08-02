namespace DataBase.Entitys
{
    /// <summary>
    /// 选项卡
    /// </summary>
    public class Tabs : EntityBase
    {
        /// <summary>
        /// 类型
        /// 长度：4
        /// </summary>
        public short? type { get; set; }
        /// <summary>
        /// 文本
        /// 长度：50
        /// </summary>
        public string? text { get; set; }
        /// <summary>
        /// 关键值
        /// 长度：4
        /// </summary>
        public short? key { get; set; }
        /// <summary>
        /// 作废时间
        /// </summary>
        public DateTime? cancelTime { get; set; }
    }
}
