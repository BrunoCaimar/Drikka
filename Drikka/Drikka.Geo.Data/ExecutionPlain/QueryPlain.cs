using System.Linq;
using System.Text;
using Drikka.Geo.Data.Contracts.ExecutionPlain;
using Drikka.Geo.Data.Contracts.Mapping;

namespace Drikka.Geo.Data.ExecutionPlain
{
    public class QueryPlain : IQueryPlain
    {
        #region Fields
        
        /// <summary>
        /// Mappings
        /// </summary>
        private readonly IMapping _mapping;

        /// <summary>
        /// Query header
        /// </summary>
        private readonly string _query;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapping">Mappings</param>
        public QueryPlain(IMapping mapping)
        {
            this._mapping = mapping;
            this._query = CreateQueryHeader();
        }

        #endregion

        #region IQueryPlain Implementation

        /// <summary>
        /// Get command text
        /// </summary>
        /// <returns>Insert command text</returns>
        public string GetText()
        {
            return this._query;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create the header text
        /// </summary>
        /// <returns>SQL select statement</returns>
        private string CreateQueryHeader()
        {
            var fields = this._mapping.AllMapping.Values.Select(x => x.FieldName.ToUpper()).ToList();
            var query = new StringBuilder();

            query.Append("SELECT ");
            query.Append(string.Join(", ", fields));
            query.Append(" FROM ");
            query.Append(this._mapping.TableName);

            return query.ToString();
        }

        #endregion

    }
}
