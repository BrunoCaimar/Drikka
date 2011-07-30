using System;
using System.Linq.Expressions;
using Drikka.Geo.Data.Contracts.Query;
using Drikka.Geo.Data.Query.Connectors;
using Drikka.Geo.Data.Query.Operators;
using Manon.Extensions.Expressions;

namespace Drikka.Geo.Data.Query
{
    /// <summary>
    /// Query extension methods
    /// </summary>
    public static class QueryExtensionMethods
    {
        public static IPredicate<T> Where<T>(this IQuery<T> query, Expression<Func<T, object>> expression)
        {
            var criteria = new Predicate<T>(query, expression.GetPropoertyInfo());

            return criteria;
        }

        #region Operators

        public static ICriteria<T> Equal<T>(this IPredicate<T> predicate, object value)
        {
            var root = (IRestorableQuery<T>)predicate;
            var @operator = new Equal();
            var criteria = new SingleCriteria<T>(root.RootQuery, predicate, @operator, value);

            root.RootQuery.Criterias.Add(criteria);

            return criteria;
        }

        public static ICriteria<T> NotEqual<T>(this IPredicate<T> predicate, object value)
        {
            var root = (IRestorableQuery<T>)predicate;
            var @operator = new NotEqual();
            var criteria = new SingleCriteria<T>(root.RootQuery, predicate, @operator, value);

            root.RootQuery.Criterias.Add(criteria);

            return criteria;
        }

        public static ICriteria<T> LessThan<T>(this IPredicate<T> predicate, object value)
        {
            var root = (IRestorableQuery<T>)predicate;
            var @operator = new LessThan();
            var criteria = new SingleCriteria<T>(root.RootQuery, predicate, @operator, value);

            root.RootQuery.Criterias.Add(criteria);

            return criteria;
        }

        public static ICriteria<T> GreaterThan<T>(this IPredicate<T> predicate, object value)
        {
            var root = (IRestorableQuery<T>)predicate;
            var @operator = new GreaterThan();
            var criteria = new SingleCriteria<T>(root.RootQuery, predicate, @operator, value);

            root.RootQuery.Criterias.Add(criteria);

            return criteria;
        }

        #endregion

        #region Connectors

        public static IPredicate<T> And<T>(this ICriteria<T> criteria, Expression<Func<T, object>> expression)
        {
            var root = (IRestorableQuery<T>)criteria;
            var predicate = new Predicate<T>(root.RootQuery, expression.GetPropoertyInfo());
            var connector = new And();
            root.RootQuery.Connectors.Add(connector);

            return predicate;
        }

        public static IPredicate<T> Or<T>(this ICriteria<T> criteria, Expression<Func<T, object>> expression)
        {
            var root = (IRestorableQuery<T>)criteria;
            var predicate = new Predicate<T>(root.RootQuery, expression.GetPropoertyInfo());
            var connector = new Or();
            root.RootQuery.Connectors.Add(connector);

            return predicate;
        }

        #endregion
        
    }
}
