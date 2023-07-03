namespace Models
{
    public class Log
    {
        public int id { get; set; }
        public string? subject { get; set; }
        public string? message { get; set; }
#pragma warning disable IDE1006 // 命名样式
        public DateTime? creationTime { get; set; }
#pragma warning restore IDE1006 // 命名样式
        public string? creator { get; set; }
    }
}