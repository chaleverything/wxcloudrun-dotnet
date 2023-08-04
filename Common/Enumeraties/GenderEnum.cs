using Common.Attributes;
using EnumsNET;
using System.ComponentModel;

namespace Common.Enumeraties
{
    public enum GenderEnum
    {
        None = 0,

        [Symbol(""), Description("男")]
        Man = 1,

        [Symbol(""), Description("女")]
        Woman = 2,
    }
}
