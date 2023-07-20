using Common.Attributes;
using EnumsNET;
using System.ComponentModel;

namespace Common.Enumeraties
{
    public enum TableTypeEnum
    {
        None = 0,

        [Symbol(""), Description("分类")]
        Categorys = 1,

        [Symbol(""), Description("商品"), PrimaryEnumMember]
        Goods = 2,
    }
}
