using System.Collections.Generic;
using System.Data;

namespace Drikka.Geo.Data.Contracts.ExecutionPlan
{
    /// <summary>
    /// plan to execute a command
    /// </summary>
    public interface IOperationPlan
    {
        /// <summary>
        /// Get command text
        /// </summary>
        /// <returns>Insert command text</returns>
        string GetText();

        /// <summary>
        /// Get parameters for a command
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="domain">Domain Object</param>
        /// <returns>List of parameters</returns>
        List<IDataParameter> GetParameters(IDbCommand command, object domain);
        
    }
}
