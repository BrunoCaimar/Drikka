using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drikka.Geo.Data.Contracts.ExecutionPlain;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.Query;

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

        /// <summary>
        /// Query translator
        /// </summary>
        private readonly IQueryTranslator _queryTranslator;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapping">Mappings</param>
        /// <param name="queryTranslator">Query translator</param>
        public QueryPlain(IMapping mapping, IQueryTranslator queryTranslator)
        {
            this._mapping = mapping;
            this._query = CreateQueryHeader();
            this._queryTranslator = queryTranslator;
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

        /// <summary>
        /// Get command text
        /// </summary>
        /// <returns>Insert command text</returns>
        public string GetText<T>(IQuery<T> query)
        {
            var header = this._query;
            var criteria = this._queryTranslator.Translate(query);

            if (!string.IsNullOrEmpty(criteria) && !string.IsNullOrWhiteSpace(criteria))
            {
                return string.Format("{0} WHERE {1}", header, criteria);
            }

            return header;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create the header text
        /// </summary>
        /// <returns>SQL select statement</returns>
        private string CreateQueryHeader()
        {
            var fields = new List<string>();

            foreach (var attribute in this._mapping.AllMapping)
            {
                string value = attribute.FieldName;
                string format;

                if (attribute.Formatters.TryGetValue(DmlType.Select, out format))
                {
                    value = string.Format(format, value);
                }

                fields.Add(value);
            }

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
