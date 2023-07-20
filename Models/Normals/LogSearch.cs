namespace Models
{
    public class LogSearch: SearchBase
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
    }
}