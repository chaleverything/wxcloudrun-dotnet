namespace Models
{
    public class LogSearch: LogDto
    {
#pragma warning disable IDE1006 // 命名样式
        public DateTime? startTime { get; set; }
#pragma warning restore IDE1006 // 命名样式

#pragma warning disable IDE1006 // 命名样式
        public DateTime? endTime { get; set; }
#pragma warning restore IDE1006 // 命名样式
    }
}