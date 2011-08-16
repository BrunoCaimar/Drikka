using System.Data;
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Contracts.ExecutionPlan
{
    public interface IQueryPlan
    {
        /// <summary>
        /// Create Plan Parameters
        /// </summary>
        /// <returns>Plan Parameters</returns>
        IPlanParameters CreatePlanParameter();

        /// <summary>
        /// Create Plan Parameters
        /// </summary>
        /// <returns>Plan Parameters</returns>
        IPlanParameters CreatePlanParameter<T>(IQuery<T> query, System.Func<IDbDataParameter> parameterFactory);

        /// <summary>
        /// Create Plan Parameters for select by ID
        /// </summary>
        /// <returns>Plan Parameters</returns>
        IPlanParameters CreatePlanParameterById(System.Func<IDbDataParameter> parameterFactory, object id);     
    }
}
