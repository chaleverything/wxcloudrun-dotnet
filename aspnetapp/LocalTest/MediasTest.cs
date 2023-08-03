using DataBase;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Data.Entity.Validation;

namespace aspnetapp.LocalTest
{
    public static class MediasTest
    {
        public static void SearchTest(MediasSearch search)
        {
            try
            {
                var context = new MediasContext();
                var query = context.Medias.AsNoTracking();
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
    }
}
