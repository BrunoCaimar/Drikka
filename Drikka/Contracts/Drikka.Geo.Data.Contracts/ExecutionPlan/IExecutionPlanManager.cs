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
        IOperationPlan GetInsertPlan(Type type);

        /// <summary>
        /// Get update plan for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>plan</returns>
        IOperationPlan GetUpdatePlan(Type type);

        /// <summary>
        /// Get select plan for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>plan</returns>
        IQueryPlan GetQueryPlan(Type type);

        /// <summary>
        /// Get delete plan for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>plan</returns>
        IOperationPlan GetDeletePlan(Type type);
    }
}
