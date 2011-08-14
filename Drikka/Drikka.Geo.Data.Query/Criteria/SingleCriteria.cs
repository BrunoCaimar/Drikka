using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Query.Criteria
{
    /// <summary>
    /// Single criteria
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class SingleCriteria<T> : AbstractSingleCriteria<T>
    {
       #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rootQuery">Root query</param>
        /// <param name="predicate">Predicate</param>
        /// <param name="operator">Operator</param>
        /// <param name="value">Value</param>
        public SingleCriteria(IQuery<T> rootQuery, IPredicate<T> predicate, IOperator @operator, object value) 
            : base(rootQuery, predicate, @operator, value)
        {
        }

        #endregion

    }
}
