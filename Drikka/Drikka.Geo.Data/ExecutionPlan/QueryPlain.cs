using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Drikka.Geo.Data.Contracts.ExecutionPlan;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.Query;
using Drikka.Geo.Data.Contracts.TypesMapping;

namespace Drikka.Geo.Data.ExecutionPlan
{
    public class QueryPlan : IQueryPlan
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

        /// <summary>
        /// Container of types
        /// </summary>
        private readonly ITypeRegister _typeRegister;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapping">Mappings</param>
        /// <param name="queryTranslator">Query translator</param>
        /// <param name="typeRegister">Type Register</param>
        public QueryPlan(IMapping mapping, IQueryTranslator queryTranslator, ITypeRegister typeRegister)
        {
            this._mapping = mapping;
            this._query = CreateQueryHeader();
            this._queryTranslator = queryTranslator;
            this._typeRegister = typeRegister;
        }

        #endregion

        #region IQueryplan Implementation

        /// <summary>
        /// Get command text
        /// </summary>
        /// <returns>Insert command text</returns>
        public string GetText()
        {
            return this._query;
        }

        public string GetTextById()
        {
            var text = new StringBuilder();
            text.Append(this._query);
            text.Append(" WHERE ");

            var names = this._mapping.IdentifiersMapping.Select(attribute => attribute.FieldName).ToList();
            var @params = names.Select(x => string.Format("{0} = @{0}", x)).ToList();
            text.Append(string.Join(", ", @params));

            return text.ToString();
        }

        /// <summary>
        /// Get parameters for a command
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="id">Domain Object</param>
        /// <returns>List of parameters</returns>
        public IDataParameter GetParameter(IDbCommand command, object id)
        {
            var @param = this._mapping.IdentifiersMapping.Select(
                    attribute => CreateParameter(command, id, attribute)).Cast<IDataParameter>().FirstOrDefault();
           
            return @param;
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
        /// Create parameter
        /// </summary>
        /// <param name="command">DbCommand</param>
        /// <param name="id">Domain</param>
        /// <param name="attribute">Attribute</param>
        /// <returns>DataParameter</returns>
        private IDbDataParameter CreateParameter(IDbCommand command, object id, IAttribute attribute)
        {
            var map = this._typeRegister.Get(attribute.PropertyInfo.PropertyType);

            var param = command.CreateParameter();

            param.Direction = ParameterDirection.Input;
            param.ParameterName = string.Format("@{0}", attribute.FieldName);
            param.DbType = map.DbType;
            param.Value = map.Converter.Write(id);

            return param;
        }

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
