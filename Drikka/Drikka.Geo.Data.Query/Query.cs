using System;
using System.Collections.Generic;
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Query
{
    /// <summary>
    /// Query
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class Query<T> : IQuery<T>
    {
        #region Properties

        /// <summary>
        /// List of criterias
        /// </summary>
        public IList<ICriteria<T>> Criterias { get; private set; }

        /// <summary>
        /// List of connectors
        /// </summary>
        public IList<IConnector> Connectors { get; private set; }

        /// <summary>
        /// Type queried
        /// </summary>
        public Type QueriedType
        {
            get
            {
                return typeof (T);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Query()
        {
            this.Criterias = new List<ICriteria<T>>();
            this.Connectors = new List<IConnector>();
        }

        #endregion

    }
}
