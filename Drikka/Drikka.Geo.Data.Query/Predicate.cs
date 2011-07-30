using System.Reflection;
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Query
{
    /// <summary>
    /// Predicate of a query
    /// </summary>
    /// <typeparam name="T">Type queried</typeparam>
    public class Predicate<T> : IPredicate<T>, IRestorableQuery<T>
    {
        #region Fields
        
        /// <summary>
        /// Root query
        /// </summary>
        private readonly IQuery<T> _rootQuery;

        /// <summary>
        /// Field
        /// </summary>
        public PropertyInfo Field { get; private set; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rootQuery">Root Query</param>
        /// <param name="field">Field</param>
        public Predicate(IQuery<T> rootQuery, PropertyInfo field)
        {
            this._rootQuery = rootQuery;
            this.Field = field;
        }

        #endregion

        #region IRestorableQuery Implementation

        /// <summary>
        /// Restore root query
        /// </summary>
        public IQuery<T> RootQuery
        {
            get { return this._rootQuery; }
        }

        #endregion

    }
}
