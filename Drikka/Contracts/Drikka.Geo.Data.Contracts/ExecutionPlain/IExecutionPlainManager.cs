using System;

namespace Drikka.Geo.Data.Contracts.ExecutionPlain
{
    /// <summary>
    /// Manage execution plains
    /// </summary>
    public interface IExecutionPlainManager
    {
        /// <summary>
        /// Get insert plain for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Plain</returns>
        IOperationPlain GetInsertPlain(Type type);

        /// <summary>
        /// Get select plain for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Plain</returns>
        IQueryPlain GetQueryPlain(Type type);
    }
}
