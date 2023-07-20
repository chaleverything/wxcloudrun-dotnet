using Common.Enumeraties;
using Common.Utilities;

namespace aspnetapp.LocalTest
{
    public static class EnumTest
    {
        public static void FlagEnumTest()
        {
            Test test = new Test();
            test.FlagEnumOperations();
        }


        public static void GetEnumTest()
        {
           var e = "分类".GetEnumByDisciption<TableTypeEnum>();
        }
    }
}
