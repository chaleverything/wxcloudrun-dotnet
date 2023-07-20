namespace Models
{
    /// <summary>
    /// 规格/型号参数值
    /// </summary>
    public class SpecValsDto : DtoBase
    {
        /// <summary>
        /// 规格/型号ID
        /// 长度：20
        /// </summary>
        public long? specId { get; set; }
        /// <summary>
        /// 软件服务ID
        /// 长度：25
        /// </summary>
        public string? saasId { get; set; }
        /// <summary>
        /// 序号
        /// 长度：4
        /// </summary>
        public short? index { get; set; }
        /// <summary>
        /// 值
        /// 长度：25
        /// </summary>
        public string? value { get; set; }
    }
}