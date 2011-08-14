using System;
using System.Linq.Expressions;
using Drikka.Geo.Data.Contracts.Query;
using Drikka.Geo.Data.Query.Criteria;
using Drikka.Geo.Data.Query.Operators.Spatial;
using Drikka.Geo.Geometry.Contracts;
using Manon.Extensions.Expressions;

namespace Drikka.Geo.Data.Query
{
    public static class SpatialQueryExtensionMethods
    {
        #region Where
        
        public static IPredicate<T> SpatialWhere<T>(this IQuery<T> query, Expression<Func<T, object>> expression) where T : IFeature
        {
            var criteria = new Predicate<T>(query, expression.GetPropoertyInfo());

            return criteria;
        }

        #endregion

        #region Spatial Operators
        
        public static ICriteria<T> Within<T>(this IPredicate<T> predicate, IGeometry value)
        {
            var root = (IRestorableQuery<T>)predicate;
            var @operator = new Within();
            var criteria = new SpatialSingleCriteria<T>(root.RootQuery, predicate, @operator, value);

            root.RootQuery.Criterias.Add(criteria);

            return criteria;
        }

        #endregion
    }
}
