using Common.Enumeraties;
using EnumsNET;
using NUnit.Framework;

namespace Common.Utilities
{
    public class Test
    {
        [Test]
        public void FlagEnumOperations()
        {
            // HasAllFlags
            Assert.IsTrue((DaysOfWeekEnum.Monday | DaysOfWeekEnum.Wednesday | DaysOfWeekEnum.Friday).HasAllFlags(DaysOfWeekEnum.Monday | DaysOfWeekEnum.Wednesday));
            Assert.IsFalse(DaysOfWeekEnum.Monday.HasAllFlags(DaysOfWeekEnum.Monday | DaysOfWeekEnum.Wednesday));

            // HasAnyFlags
            Assert.IsTrue(DaysOfWeekEnum.Monday.HasAnyFlags(DaysOfWeekEnum.Monday | DaysOfWeekEnum.Wednesday));
            Assert.IsFalse((DaysOfWeekEnum.Monday | DaysOfWeekEnum.Wednesday).HasAnyFlags(DaysOfWeekEnum.Friday));

            // CombineFlags ~ bitwise OR
            Assert.AreEqual(DaysOfWeekEnum.Monday | DaysOfWeekEnum.Wednesday, DaysOfWeekEnum.Monday.CombineFlags(DaysOfWeekEnum.Wednesday));
            Assert.AreEqual(DaysOfWeekEnum.Monday | DaysOfWeekEnum.Wednesday | DaysOfWeekEnum.Friday, FlagEnums.CombineFlags(DaysOfWeekEnum.Monday, DaysOfWeekEnum.Wednesday, DaysOfWeekEnum.Friday));

            // CommonFlags ~ bitwise AND
            Assert.AreEqual(DaysOfWeekEnum.Monday, DaysOfWeekEnum.Monday.CommonFlags(DaysOfWeekEnum.Monday | DaysOfWeekEnum.Wednesday));
            Assert.AreEqual(DaysOfWeekEnum.None, DaysOfWeekEnum.Monday.CommonFlags(DaysOfWeekEnum.Wednesday));

            // RemoveFlags
            Assert.AreEqual(DaysOfWeekEnum.Wednesday, (DaysOfWeekEnum.Monday | DaysOfWeekEnum.Wednesday).RemoveFlags(DaysOfWeekEnum.Monday));
            Assert.AreEqual(DaysOfWeekEnum.None, (DaysOfWeekEnum.Monday | DaysOfWeekEnum.Wednesday).RemoveFlags(DaysOfWeekEnum.Monday | DaysOfWeekEnum.Wednesday));

            // GetFlags, splits out the individual flags in increasing significance bit order
            var flags = DaysOfWeekEnum.Weekend.GetFlags().ToList();
            Assert.AreEqual(2, flags.Count);
            Assert.AreEqual(DaysOfWeekEnum.Sunday, flags[0]);
            Assert.AreEqual(DaysOfWeekEnum.Saturday, flags[1]);
        }
    }
}
