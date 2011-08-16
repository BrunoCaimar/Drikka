using System.Collections.Generic;
using System.Data;
using Drikka.Geo.Data.Contracts.ExecutionPlan;

namespace Drikka.Geo.Data.ExecutionPlan
{
    /// <summary>
    /// Plan text and parameters
    /// </summary>
    public class PlanParameters : IPlanParameters
    {
        #region Fields
        
        /// <summary>
        /// Sql text to execute
        /// </summary>
        public string SqlText { get; private set; }

        /// <summary>
        /// Sql parameter
        /// </summary>
        public IList<IDbDataParameter> Parameters { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text"></param>
        /// <param name="parameters"></param>
        public PlanParameters(string text, IList<IDbDataParameter> parameters)
        {
            this.SqlText = text;
            this.Parameters = parameters;
        }

        #endregion

    }
}
