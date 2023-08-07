using System.Linq.Expressions;

namespace Common.Utilities
{
    public static class LinqExtends
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> query, string sortBy, string direction) where T : class
        {
            if (string.IsNullOrWhiteSpace(sortBy) || string.IsNullOrWhiteSpace(direction))
            {
                return query;
            }

            ParameterExpression parameterExpression = Expression.Parameter(query.ElementType, string.Empty);
            MemberExpression memberExpression = null;
            string[] array = sortBy.Split('.');
            string[] array2 = array;
            foreach (string propertyName in array2)
            {
                memberExpression = ((memberExpression != null) ? Expression.Property(memberExpression, propertyName) : Expression.Property(parameterExpression, propertyName));
            }

            LambdaExpression expression = Expression.Lambda(memberExpression, parameterExpression);
            string methodName = (direction.ToUpper() == "DESC" ? "OrderByDescending" : "OrderBy");
            Expression expression2 = Expression.Call(typeof(Queryable), methodName, new Type[2] { query.ElementType, memberExpression.Type }, query.Expression, Expression.Quote(expression));
            return (IQueryable<T>)query.Provider.CreateQuery(expression2);

        }
    }
}
