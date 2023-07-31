using Common.Attributes;
using EnumsNET;
using System.ComponentModel;

namespace Common.Enumeraties
{
    public enum MediaTypeEnum
    {
        None = 0,

        [Symbol(""), Description("图片"), PrimaryEnumMember]
        Image = 1,

        [Symbol(""), Description("视频")]
        Video = 2,
    }
}
