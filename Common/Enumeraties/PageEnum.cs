using Common.Attributes;
using EnumsNET;
using System.ComponentModel;

namespace Common.Enumeraties
{
    public enum PageEnum
    {
        [Symbol(""), Description("主页"), PrimaryEnumMember]
        Home = 0,
    }
}
