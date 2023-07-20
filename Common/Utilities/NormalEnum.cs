using EnumsNET;
using System.ComponentModel;

namespace Common.Utilities
{
    public static class NormalEnum
    {
        public static T GetEnumByDisciption<T>(this string disciption) where T : struct, Enum
        {
            foreach (var member in Enums.GetValues<T>())
            {
                if (disciption.Equals(member.GetAttributes()?.Get<DescriptionAttribute>()?.Description))
                {
                    return member;
                }
            }
            return default(T);
        }
    }
}
