using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
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

        #region IQueryPlan Implementation

        /// <summary>
        /// Create Plan Parameters
        /// </summary>
        /// <returns>Plan Parameters</returns>
        public IPlanParameters CreatePlanParameter()
        {
            var builder = new StringBuilder();
            builder.Append(this._query);

            return new PlanParameters(builder.ToString(), new List<IDbDataParameter>());
        }

        /// <summary>
        /// Create Plan Parameters
        /// </summary>
        /// <returns>Plan Parameters</returns>
        public IPlanParameters CreatePlanParameter<T>(IQuery<T> query, Func<IDbDataParameter> parameterFactory)
        {
            var builder = new StringBuilder();
            builder.Append(this._query);

            var criteria = this._queryTranslator.Translate(query);

            if (!string.IsNullOrEmpty(criteria.SqlText) && !string.IsNullOrWhiteSpace(criteria.SqlText))
            {
                builder.Append(" WHERE ");
                builder.Append(criteria.SqlText);
            }

            var @params = new List<IDbDataParameter>();
            foreach (var parameter in criteria.Parameters)
            {
                var map = this._typeRegister.Get(parameter.DataType);

                var param = parameterFactory();
                param.Direction = ParameterDirection.Input;
                param.ParameterName = string.Format("@{0}", parameter.ParamName);
                param.DbType = map.DbType;
                param.Value = map.Converter.Write(parameter.Value);

                @params.Add(param);
            }

            return new PlanParameters(builder.ToString(), @params);
        }

        /// <summary>
        /// Create Plan Parameters for select by ID
        /// </summary>
        /// <returns>Plan Parameters</returns>
        public IPlanParameters CreatePlanParameterById(Func<IDbDataParameter> parameterFactory, object id)
        {
            var text = new StringBuilder();
            text.Append(this._query);
            text.Append(" WHERE ");

            var names = this._mapping.IdentifiersMapping.Select(attribute => attribute.FieldName).ToList();
            var @params = names.Select(x => string.Format("{0} = @{0}", x)).ToList();
            text.Append(string.Join(", ", @params));

            var list = new List<IDbDataParameter>();
            foreach (var attribute in this._mapping.IdentifiersMapping)
            {
                var map = this._typeRegister.Get(attribute.PropertyInfo.PropertyType);

                var param = parameterFactory();
                param.Direction = ParameterDirection.Input;
                param.ParameterName = string.Format("@{0}", attribute.FieldName);
                param.DbType = map.DbType;
                param.Value = map.Converter.Write(id);

                list.Add(param);
            }

            return new PlanParameters(text.ToString(), list);
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
