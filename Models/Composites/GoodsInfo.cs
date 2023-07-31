namespace Models
{
    public class GoodsInfo: GoodsDto
    {
        /// <summary>
        /// 主图
        /// </summary>
        public string? primaryImage { get; set; }

        /// <summary>
        /// 主图内容
        /// </summary>
        public string? primaryImageContent { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public List<CombMedias>? images { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public List<CombMedias>? desc { get; set; }

        /// <summary>
        /// 类别ID集合
        /// </summary>
        public List<string>? categoryIdList
        {
            get
            {
                return categoryIds?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        /// <summary>
        /// 规格集合
        /// </summary>
        public List<SpecInfo>? specList { get; set; }

        /// <summary>
        /// SKU集合
        /// </summary>
        public List<SkuInfo>? skuList { get; set; }
    }
}
