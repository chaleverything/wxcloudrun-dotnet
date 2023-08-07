using Common.Enumeraties;
using Common.Utilities;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace aspnetapp.LocalTest
{
    public static class EntityTest
    {
        public static void SearchMediasTest()
        {
            var search = new MediasSearch { tableType = (short)TableTypeEnum.None, mType = (short)MediaTypeEnum.Image, tableId = (long)PageEnum.Home };
            try
            {
                var context = new MediasContext();
                var query = context.Medias;
                //var context = new CategorysContext();
                //var query = context.Categorys.AsNoTracking();

                //if (search.tableType.HasValue)
                //{
                //    query = query.Where(n => n.tableType == search.tableType);
                //}
                //if (search.mType.HasValue)
                //{
                //    query = query.Where(n => n.mType == search.mType);
                //}
                //if (search.tableId.HasValue)
                //{
                //    query = query.Where(n => n.tableId == search.tableId);
                //}
                //if (search.tableIds?.Count > 0)
                //{
                //    query = query.Where(n => n.tableId.HasValue && search.tableIds.Contains(n.tableId.Value));
                //}
                //if (!string.IsNullOrWhiteSpace(search.flag))
                //{
                //    query = query.Where(n => n.flag == search.flag);
                //}
                var lst = query.ToList();
            }
            catch (DbEntityValidationException e)
            {
                var msg = e.EntityValidationErrors.ToArray()[0].ValidationErrors.ToArray()[0].ErrorMessage;
            }
            catch (Exception ex)
            {

            }
        }

        public static void GetPopularsTest()
        {
            SearchBase search = new MediasSearch { pageSize = 16 };
            try
            {
                var context = new KeywordHistorysContext();
                (int total, int pageIndex, int pageSize, string sortBy, string direction) = search.GetDefaultCondition();
#pragma warning disable CS8602 // 解引用可能出现空引用。
                var query = context.KeywordHistorys
                    .GroupBy(m => new { m.content })
                    .Select(n => new KeywordHistorysSummary
                    {
                        content = n.Key.content,
                        number = n.Count(),
                        creationTime = n.Where(k => k.creationTime.HasValue).OrderBy(k => k.creationTime).FirstOrDefault().creationTime
                    });
#pragma warning restore CS8602 // 解引用可能出现空引用。

                var result = query.OrderByDescending(n => n.number).ThenBy(n => n.creationTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(n => n.content).ToList();

            }
            catch (DbEntityValidationException e)
            {
                var msg = e.EntityValidationErrors.ToArray()[0].ValidationErrors.ToArray()[0].ErrorMessage;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
