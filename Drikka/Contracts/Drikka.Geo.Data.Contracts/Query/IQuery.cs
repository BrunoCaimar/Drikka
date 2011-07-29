using System;
using System.Collections.Generic;

namespace Drikka.Geo.Data.Contracts.Query
{
    /// <summary>
    /// Query
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public interface IQuery<T>
    {
        /// <summary>
        /// List of criterias
        /// </summary>
        IList<ICriteria<T>> Criterias { get; }

        /// <summary>
        /// List of connectors
        /// </summary>
        IList<IConnector> Connectors { get; }

        /// <summary>
        /// Type queried
        /// </summary>
        Type QueriedType { get; }
    }
}
