
using Drikka.Geo.Data.Contracts.Sql;

namespace Drikka.Geo.Data.Contracts.Query
{
    /// <summary>
    /// Query translator, translate from query object to SQL
    /// </summary>
    public interface IQueryTranslator
    {
        /// <summary>
        /// Translate
        /// </summary>
        /// <param name="query">Query object</param>
        /// <returns>SQL</returns>
        ISqlTranslation Translate<T>(IQuery<T> query);
    }
}
