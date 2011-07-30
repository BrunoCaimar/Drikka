using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Query
{
    /// <summary>
    /// Single criteria
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class SingleCriteria<T> : ICriteria<T>, IRestorableQuery<T>
    {
        #region Fields
        
        /// <summary>
        /// Root query
        /// </summary>
        private readonly IQuery<T> _rootQuery;

        #endregion

        #region Properties

        /// <summary>
        /// Predicate
        /// </summary>
        public IPredicate<T> Predicate { get; private set; }

        /// <summary>
        /// Operator
        /// </summary>
        public IOperator Operator { get; private set; }

        /// <summary>
        /// Value
        /// </summary>
        public object Value { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rootQuery">Root query</param>
        /// <param name="predicate">Predicate</param>
        /// <param name="operator">Operator</param>
        /// <param name="value">Value</param>
        public SingleCriteria(IQuery<T> rootQuery, IPredicate<T> predicate, IOperator @operator, object value)
        {
            this._rootQuery = rootQuery;
            this.Predicate = predicate;
            this.Operator = @operator;
            this.Value = value;
        }

        #endregion

        #region IRestorableQuery Implementation

        /// <summary>
        /// Root query
        /// </summary>
        public IQuery<T> RootQuery
        {
            get { return this._rootQuery; }
        }

        #endregion

    }
}
