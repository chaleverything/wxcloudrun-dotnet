using Common.Utilities;
using Models;

namespace aspnetapp.LocalTest
{
    public static class CommTest
    {
        public static void FillChildrenTest()
        {
            var lstAll = new List<CategoryTree>
            {
                new CategoryTree{ id = 1, name = "大类1" },
                new CategoryTree{ id = 2, name = "大类2" },
                new CategoryTree{ id = 3, name = "大类3" },
                new CategoryTree{ id = 4, name = "大类1-小类1", parentId = 1 },
                new CategoryTree{ id = 5, name = "大类1-小类2", parentId = 1 },
                new CategoryTree{ id = 6, name = "大类1-小类3", parentId = 1 },
                new CategoryTree{ id = 7, name = "大类2-小类1", parentId = 2 },
                new CategoryTree{ id = 8, name = "大类2-小类2", parentId = 2 },
                new CategoryTree{ id = 9, name = "大类3-小类1", parentId = 3 },
                new CategoryTree{ id = 10, name = "大类2-小类1-分类1", parentId = 7 },
                new CategoryTree{ id = 11, name = "大类2-小类1-分类2", parentId = 7 },
                new CategoryTree{ id = 12, name = "大类3-小类1-分类1", parentId = 9 },
            };

            var lst = lstAll.Where(n => !n.parentId.HasValue).ToList();

            lst.ForEach(m =>
            {
                m.FillChildren(lstAll);
            });
        }

        public static void DefaultConditionTest()
        {
            KeywordHistorysSearch search = new KeywordHistorysSearch();
            (int total, int pageIndex, int pageSize, string sortBy, string direction) = search.GetDefaultCondition();
        }
    }
}
