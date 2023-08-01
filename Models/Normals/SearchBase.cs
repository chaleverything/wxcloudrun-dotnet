namespace Models
{
    public abstract class SearchBase
    {
#pragma warning disable IDE1006 // 命名样式
        public DateTime? startTime { get; set; }
#pragma warning restore IDE1006 // 命名样式

#pragma warning disable IDE1006 // 命名样式
        public DateTime? endTime { get; set; }
#pragma warning restore IDE1006 // 命名样式

        /// <summary>
        /// 当前页
        /// </summary>
        public int? pageIndex { get; set; }
        /// <summary>
        /// 每页行数
        /// </summary>
        public int? pageSize { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string? sortBy { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public string? direction { get; set; }
    }
}
