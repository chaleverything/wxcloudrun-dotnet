using Common.Attributes;
using System.ComponentModel;

namespace Common.Enumeraties
{
    [Flags]
    public enum OperatorEnum
    {
        None = 0,

        /// <summary>
        /// 等于
        /// </summary>
        [Symbol(""), Description("等于"), Operator("=={0}")]
        Equal = 1,

        /// <summary>
        /// 包含
        /// </summary>
        [Symbol(""), Description("包含"), Operator(".Contains({0})")]
        Contants = 2,

        /// <summary>
        /// 且
        /// </summary>
        [Symbol(""), Description("且"), Operator(" && ")]
        And = 3,

        /// <summary>
        /// 或
        /// </summary>
        [Symbol(""), Description("或"), Operator(" || ")]
        Or = 4,
    }
}
