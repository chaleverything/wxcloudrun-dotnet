namespace Models
{
    public class CategoryTree: ISuboTree
    {
        public long id { get; set; }

        public long? parentId { get; set; }

        public string? groupId { get; set; }

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
        /// 子分类
        /// </summary>
        public List<CategoryTree>? children { get; set; }

        /// <summary>
        /// 设置子级对象
        /// </summary>
        /// <param name="lst"></param>
        public void SetChildren(object lst)
        {
            children = (List<CategoryTree>)lst;
        }
    }
}
