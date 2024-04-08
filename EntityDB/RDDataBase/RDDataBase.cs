using MindrayApp.Model.RD;
using System.Data.Entity;
using System.Linq.Dynamic.Core;

namespace EntityDataBase
{
    public class RDDataBase
    {
        /// <summary>
        /// Query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filters"></param>
        /// <returns></returns>
        public List<T> Query<T>(string filters) where T : class
        {
            using var db = new EAWP_RDEntities();
            return db.Set<T>().AsNoTracking().Where(filters).ToList();
        }

        /// <summary>
        /// Find
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filters"></param>
        /// <returns></returns>
        public T? Find<T>(string filters) where T : class
        {
            using var db = new EAWP_RDEntities();
            return db.Set<T>().AsNoTracking().FirstOrDefault(filters);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filters"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
        public bool Update<T>(string filters, Dictionary<string, object> updateExpression) where T : class
        {
            using var db = new EAWP_RDEntities();
            var lstEntity = db.Set<T>().Where(filters).ToList();
            lstEntity.ForEach(n =>
            {
                foreach(var item in updateExpression)
                {
                    typeof(T).GetProperty(name: item.Key)?.SetValue(n, updateExpression[item.Key]);
                }
                
                db.Entry(n).State = EntityState.Modified;
            });


            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filters"></param>
        /// <returns></returns>
        public bool Remove<T>(string filters) where T : class
        {
            using var db = new EAWP_RDEntities();
            db.Set<T>().RemoveRange(db.Set<T>().Where(filters));
            return db.SaveChanges() > 0;
        }
    }
}
