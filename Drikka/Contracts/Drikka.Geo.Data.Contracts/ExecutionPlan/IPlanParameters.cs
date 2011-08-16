using System.Collections.Generic;
using System.Data;

namespace Drikka.Geo.Data.Contracts.ExecutionPlan
{
    /// <summary>
    /// Plan text and parameters
    /// </summary>
    public interface IPlanParameters
    {
        /// <summary>
        /// Sql text to execute
        /// </summary>
        string SqlText { get;  }

        /// <summary>
        /// Sql parameter
        /// </summary>
        IList<IDbDataParameter> Parameters { get; }
    }
}
