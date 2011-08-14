using System.Collections.Generic;
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Postgre.Query
{
    /// <summary>
    /// Sql translation
    /// </summary>
    public class QueryTranslation : IQueryTranslation
    {
        #region Properties

        /// <summary>
        /// Sql Text
        /// </summary>
        public string SqlText { get; set; }

        /// <summary>
        /// Command parameters
        /// </summary>
        public IDictionary<string, object> Parameters { get; set; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public QueryTranslation()
        {
            this.Parameters = new Dictionary<string, object>();
        }

        #endregion
    }
}
