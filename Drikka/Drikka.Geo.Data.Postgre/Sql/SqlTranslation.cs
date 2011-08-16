using System.Collections.Generic;
using Drikka.Geo.Data.Contracts.Sql;

namespace Drikka.Geo.Data.Postgre.Sql
{
    /// <summary>
    /// Sql translation
    /// </summary>
    public class SqlTranslation : ISqlTranslation
    {
        #region Properties

        /// <summary>
        /// Sql Text
        /// </summary>
        public string SqlText { get; set; }

        /// <summary>
        /// Command parameters
        /// </summary>
        public IList<ISqlParam> Parameters { get; set; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public SqlTranslation()
        {
            this.Parameters = new List<ISqlParam>();
        }

        #endregion
    }
}
