namespace Models
{
    /// <summary>
    /// 仓库
    /// </summary>
    public class StoresDto : DtoBase
    {
        /// <summary>
        /// 序号
        /// 长度：4
        /// </summary>
        public short? index { get; set; }
        /// <summary>
        /// 名称
        /// 长度120
        /// </summary>
        public string? name { get; set; }
    }
}