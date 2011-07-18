using System;
using System.Linq.Expressions;
using Manon.Extensions.Expressions;

namespace Drikka.Geo.Data.Query
{
    public static class QueryExtensionMethods
    {
        public static IPredicate<T> Where<T>(this IQuery<T> query, Expression<Func<T, object>> expression)
        {
            var criteria = new SingleCriteria<T>(query, expression.GetPropoertyInfo());

            return null;
        }

        #region Operators

        public static ICriteria<T> Equal<T>(this IPredicate<T> predicate, object value)
        {
            return null;
        }

        public static ICriteria<T> NotEqual<T>(this IPredicate<T> predicate, object value)
        {
            return null;
        }

        public static ICriteria<T> LessThan<T>(this IPredicate<T> predicate, object value)
        {
            return null;
        }

        public static ICriteria<T> GreaterThan<T>(this IPredicate<T> predicate, object value)
        {
            return null;
        }

        #endregion

        #region Connectors

        public static IPredicate<T> And<T>(this ICriteria<T> criteria, Expression<Func<T, object>> expression)
        {
            return null;
        }

        public static IPredicate<T> Or<T>(this ICriteria<T> criteria, Expression<Func<T, object>> expression)
        {
            return null;
        }

        public static IPredicate<T> And<T>(this ICriteria<T> criteria)
        {
            return null;
        }

        #endregion

        public static IPredicate<T> Brackets<T>(this IPredicate<T> predicate, Expression<Func<Func<Expression<Func<T, object>>, IPredicate<T>>, object>> expression)
        {
            return null;
        }

    }
}
