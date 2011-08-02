using System;

namespace Drikka.Geo.Data.Contracts.ExecutionPlan
{
    /// <summary>
    /// Manage execution plans
    /// </summary>
    public interface IExecutionPlanManager
    {
        /// <summary>
        /// Get insert plan for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>plan</returns>
        IOperationPlan GetInsertplan(Type type);

        /// <summary>
        /// Get select plan for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>plan</returns>
        IQueryPlan GetQueryplan(Type type);

        /// <summary>
        /// Get delete plan for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>plan</returns>
        IOperationPlan GetDeleteplan(Type type);
    }
}
