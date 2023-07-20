namespace Models
{
    public class CategorysSearch : SearchBase
    {
        /// <summary>
        /// 父级分类ID
        /// 长度：20
        /// </summary>
        public long? parentId { get; set; }
        /// <summary>
        /// 名称
        /// 长度：20
        /// </summary>
        public string? name { get; set; }
    }
}