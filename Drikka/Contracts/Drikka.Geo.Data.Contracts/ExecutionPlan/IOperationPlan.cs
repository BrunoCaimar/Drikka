using System.Data;

namespace Drikka.Geo.Data.Contracts.ExecutionPlan
{
    /// <summary>
    /// plan to execute a command
    /// </summary>
    public interface IOperationPlan
    {
        /// <summary>
        /// Create Plan Parameters
        /// </summary>
        /// <returns>Plan Parameters</returns>
        IPlanParameters CreatePlanParameter(System.Func<IDbDataParameter> parameterFactory, object domain);        
        
    }
}
