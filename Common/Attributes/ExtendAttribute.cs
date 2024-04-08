using System.ComponentModel;
using System.Reflection;

namespace Common.Attributes
{
    public static class ExtendAttribute
    {
        #region 通用描述

        #region 获取通用描述属性值

        /// <summary>
        /// 获取通用描述属性值
        /// </summary>
        /// <param name="enumName"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumName, int row = 0)
        {
            var fieldInfo = enumName.GetType().GetField(enumName.ToString());
            var attributes = fieldInfo?.GetDescAttrs();
            return attributes != null && attributes.Length > row ? attributes[row].Description : enumName.ToString();
        }

        #endregion 获取通用描述属性值

        #region 通过枚举对象获取通用描述所有属性值

        /// <summary>
        /// 通过枚举对象获取通用描述所有属性值
        /// </summary>
        /// <param name="fieldInfo"></param>
        /// <returns></returns>
        private static DescriptionAttribute[] GetDescAttrs(this FieldInfo fieldInfo)
        {
            return (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        }

        #endregion 通过枚举对象获取通用描述所有属性值

        #endregion 通用描述

        #region 运算符

        #region 获取运算符属性值

        /// <summary>
        /// 获取运算符属性值
        /// </summary>
        /// <param name="enumName"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string GetOperator(this Enum enumName, int row = 0)
        {
            var fieldInfo = enumName.GetType().GetField(enumName.ToString());
            var attributes = fieldInfo?.GetOperatorAttributes();
            return attributes != null && attributes.Length > row ? attributes[row].Description : enumName.ToString();
        }

        #endregion 获取运算符属性值

        #region 通过枚举对象获取多语言所有属性值

        /// <summary>
        /// 通过枚举对象获取多语言所有属性值
        /// </summary>
        /// <param name="fieldInfo"></param>
        /// <returns></returns>
        private static OperatorAttribute[] GetOperatorAttributes(this FieldInfo fieldInfo)
        {
            return (OperatorAttribute[])fieldInfo.GetCustomAttributes(typeof(OperatorAttribute), false);
        }

        #endregion 通过枚举对象获取多语言所有属性值

        #endregion 运算符
    }
}
