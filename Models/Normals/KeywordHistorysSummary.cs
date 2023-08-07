namespace Models
{
    public class KeywordHistorysSummary: DtoBase
    {
        /// <summary>
        /// 关键字
        /// 长度：100
        /// </summary>
        public string? content { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int? number { get; set; }
    }
}