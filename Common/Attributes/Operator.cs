namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class |
     AttributeTargets.Constructor |
     AttributeTargets.Field |
     AttributeTargets.Method |
     AttributeTargets.Property,
     AllowMultiple = true)]
    public class OperatorAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n"></param>
        public OperatorAttribute(string n) => Description = n;

        /// <summary>
        /// Description
        /// </summary>
        public string Description
        {
            get; set;
        }
    }
}
