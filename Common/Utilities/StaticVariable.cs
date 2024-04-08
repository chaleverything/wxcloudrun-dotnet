using System.Linq.Expressions;

namespace Common.Utilities
{
    /// <summary>
    /// 静态变量
    /// </summary>
    public static class StaticVariable
    {
        public static List<string> _DSNOPERA = new List<string> { "==", ">=", "<=", "!=", ">", "<", "=" };

        //public static List<string> _DSNOPERA = typeof(ExpressionType).GetFields()
            //.Where(f => f.FieldType == typeof(ExpressionType))
            //.Select(f => f.Name)
            //.ToList();
    }
}
