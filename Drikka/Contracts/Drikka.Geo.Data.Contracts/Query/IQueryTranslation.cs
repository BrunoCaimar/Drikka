using System.Collections.Generic;

namespace Drikka.Geo.Data.Contracts.Query
{
    /// <summary>
    /// Sql translation
    /// </summary>
    public interface IQueryTranslation
    {
        /// <summary>
        /// Sql Text
        /// </summary>
        string SqlText { get; }

        /// <summary>
        /// Command parameters
        /// </summary>
        IDictionary<string, object> Parameters { get; }
    }
}
