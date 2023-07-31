namespace Models
{
    public class GoodsInfoSearch : GoodsInfo
    {
        /// <summary>
        /// 仓库ID集合
        /// </summary>
        public List<long>? lstStoreId { get; set; }
    }
}