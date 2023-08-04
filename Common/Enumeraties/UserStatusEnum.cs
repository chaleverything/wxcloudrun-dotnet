using Common.Attributes;
using System.ComponentModel;

namespace Common.Enumeraties
{
    public enum UserStatusEnum
    {
        [Symbol(""), Description("未登记")]
        UnRegistered = 0,

        [Symbol(""), Description("正常使用")]
        Normal = 1,

        [Symbol(""), Description("贵宾")]
        VIP = 2,

        [Symbol(""), Description("受限制")]
        Restricted = 3,

        [Symbol(""), Description("禁用")]
        Forbidden = 4,

        [Symbol(""), Description("黑名单")]
        Blacklist = 5,

        [Symbol(""), Description("挂起")]
        Holding = 6,

        [Symbol(""), Description("使用中")]
        Usable = UnRegistered | Normal | VIP | Restricted,

        [Symbol(""), Description("注册使用中")]
        Activation = Normal | VIP | Restricted,
    }
}
