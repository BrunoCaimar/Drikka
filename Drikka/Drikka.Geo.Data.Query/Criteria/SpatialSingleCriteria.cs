using Drikka.Geo.Data.Contracts.Query;
using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Data.Query.Criteria
{
    /// <summary>
    /// Spatial Single criteria
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class SpatialSingleCriteria<T> : AbstractSingleCriteria<T>
    {
        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rootQuery">Root query</param>
        /// <param name="predicate">Predicate</param>
        /// <param name="operator">Operator</param>
        /// <param name="value">Value</param>
        public SpatialSingleCriteria(IQuery<T> rootQuery, IPredicate<T> predicate, ISpatialOperator @operator, IGeometry value)
            :base(rootQuery, predicate, @operator, value)
        {
        }

        #endregion

    }
}
