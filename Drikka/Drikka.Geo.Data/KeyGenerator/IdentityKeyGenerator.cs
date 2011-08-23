using System.Data;
using Drikka.Geo.Data.Contracts.ExecutionPlan;

namespace Drikka.Geo.Data.KeyGenerator
{
    public class IdentityKeyGenerator : IInsertKeygen
    {
        public object GenerateKey(IDbCommand command)
        {
            command.CommandType = CommandType.Text;
            command.CommandText = CreateCommandText();

            var result = command.ExecuteScalar();

            return result;
        }

        private static string CreateCommandText()
        {
            const string sqlText = "SELECT @@IDENTITY";

            return sqlText;
        }
    }
}
