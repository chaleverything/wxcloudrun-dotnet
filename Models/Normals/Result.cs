namespace Models
{
    public class Result
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSucc { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string? Code { get; set; }

        public string? Msg { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public object? ReturnValue { get; set; }
    }
}
