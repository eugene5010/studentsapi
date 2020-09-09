using System;
using System.Linq;
using System.Linq.Expressions;

namespace StudentsApi
{
    public static class QueryHelper
    {
        public static IQueryable<T> IfWhere<T>(this IQueryable<T> queryable, Func<bool> predicate,
            Expression<Func<T, bool>> predicateExpression)
        {
            return predicate() ? queryable.Where(predicateExpression) : queryable;
        }

        public static IQueryable<T> SkipWhen<T>(this IQueryable<T> queryable, Func<bool> predicate, int skipCount)
        {
            return predicate() ? queryable.Skip(skipCount) : queryable;
        }

        public static IQueryable<T> TakeWhen<T>(this IQueryable<T> queryable, Func<bool> predicate, int takeCount)
        {
            return predicate() ? queryable.Take(takeCount) : queryable;
        }
    }
}
