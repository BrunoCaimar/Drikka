using System.Collections.Generic;
using System.Data;
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Contracts.ExecutionPlain
{
    public interface IQueryPlain
    {
        /// <summary>
        /// Get command text
        /// </summary>
        /// <returns>Insert command text</returns>
        string GetText();

        /// <summary>
        /// Get command text
        /// </summary>
        /// <returns>Insert command text</returns>
        string GetTextById();

        /// <summary>
        /// Get command text
        /// </summary>
        /// <returns>Insert command text</returns>
        string GetText<T>(IQuery<T> query);

        /// <summary>
        /// Get parameters for a command
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="id">Domain Object</param>
        /// <returns>List of parameters</returns>
        IDataParameter GetParameter(IDbCommand command, object id);
    }
}
