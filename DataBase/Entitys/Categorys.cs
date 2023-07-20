namespace DataBase.Entitys
{
    /// <summary>
    /// 分类
    /// </summary>
    public class Categorys: EntityBase
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
        /// <summary>
        /// 略图地址
        /// 长度：200
        /// </summary>
        public string? thumbnailPath { get; set; }
        /// <summary>
        /// 略图内容
        /// </summary>
        public byte[]? thumbnailContent { get; set; }
        /// <summary>
        /// 作废时间
        /// </summary>
        public DateTime? cancelTime { get; set; }
    }
}
