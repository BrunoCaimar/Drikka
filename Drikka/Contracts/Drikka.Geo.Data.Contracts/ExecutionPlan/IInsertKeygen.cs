using System.Data;

namespace Drikka.Geo.Data.Contracts.ExecutionPlan
{
    public interface IInsertKeygen
    {
        object GenerateKey(IDbCommand command);
    }
}
