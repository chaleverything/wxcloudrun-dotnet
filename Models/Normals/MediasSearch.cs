namespace Models
{
    public class MediasSearch : SearchBase
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
        /// 标识
        /// 长度：20
        /// </summary>
        public string? flag { get; set; }
        /// <summary>
        /// 所属表ID
        /// </summary>
        public List<long>? tableIds { get; set; }
    }
}