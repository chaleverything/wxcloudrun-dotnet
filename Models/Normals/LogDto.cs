namespace Models
{
    /// <summary>
    /// 日志
    /// </summary>
    public class LogDto: DtoBase
    {
        /// <summary>
        /// 主题
        /// 长度：100
        /// </summary>
        public string? subject { get; set; }
        /// <summary>
        /// 内容
        /// 长度：2000
        /// </summary>
        public string? message { get; set; }
        /// <summary>
        /// 创建人
        /// 长度：15
        /// </summary>
        public string? creator { get; set; }
    }
}