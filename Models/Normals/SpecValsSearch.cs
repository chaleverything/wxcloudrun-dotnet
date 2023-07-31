namespace Models
{
    public class SpecValsSearch : SearchBase
    {
        /// <summary>
        /// 规格ID集合
        /// </summary>
        public List<long>? specIds { get; set; }
        /// <summary>
        /// 值
        /// 长度：25
        /// </summary>
        public string? value { get; set; }
    }
}