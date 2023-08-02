namespace DataBase.Entitys
{
    /// <summary>
    /// 多媒体介质
    /// </summary>
    public class Medias : EntityBase
    {
        /// <summary>
        /// 所属表类型
        /// 长度：4
        /// </summary>
        public short? tableType { get; set; }
        /// <summary>
        /// 媒介类型
        /// 长度：4
        /// </summary>
        public short? mType { get; set; }
        /// <summary>
        /// 所属表ID
        /// 长度：20
        /// </summary>
        public long? tableId { get; set; }
        /// <summary>
        /// 媒介地址
        /// 长度：250
        /// </summary>
        public string? path { get; set; }
        /// <summary>
        /// 媒介内容
        /// </summary>
        public byte[]? content { get; set; }
        /// <summary>
        /// 标识
        /// 长度：20
        /// </summary>
        public string? flag { get; set; }
    }
}
