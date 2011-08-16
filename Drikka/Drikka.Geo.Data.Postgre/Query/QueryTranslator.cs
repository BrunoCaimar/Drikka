using System;
using System.Collections.Generic;
using System.Text;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.Query;
using Drikka.Geo.Data.Contracts.Sql;
using Drikka.Geo.Data.Postgre.Sql;
using Drikka.Geo.Data.Query.Connectors;
using Drikka.Geo.Data.Query.Operators;
using Drikka.Geo.Data.Query.Operators.Spatial;
using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Data.Postgre.Query
{
    /// <summary>
    /// Query translator
    /// </summary>
    public class QueryTranslator : IQueryTranslator
    {
        #region Fields
        
        /// <summary>
        /// Mapping manager
        /// </summary>
        private readonly IMappingManager _mappingManager;

        /// <summary>
        /// Operators available
        /// </summary>
        private readonly IDictionary<Type, Func<string, string, string >> _operators;

        /// <summary>
        /// Spatial Operators available
        /// </summary>
        private readonly IDictionary<Type, Func<IGeometry, string, string, string>> _spatialOperators;

        /// <summary>
        /// Connector available
        /// </summary>
        private readonly IDictionary<Type, Func<string>> _connectors;

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mappingManager">Mapping manager</param>
        public QueryTranslator(IMappingManager mappingManager)
        {
            this._mappingManager = mappingManager;
            this._operators = MapOperators();
            this._spatialOperators = MapSpatialOperators();
            this._connectors = MapConnectors();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Translate query
        /// </summary>
        /// <typeparam name="T">Domain type</typeparam>
        /// <param name="query">Query</param>
        /// <returns>Query translated</returns>
        public ISqlTranslation Translate<T>(IQuery<T> query)
        {
            var map = this._mappingManager.GetMapping(query.QueriedType);
            var sql = new StringBuilder();
            var connectors = query.Connectors.GetEnumerator();
            var translated = new SqlTranslation();
            var paramCount = 0;

            foreach (var criteria in query.Criterias)
            {
                var attr = map.GetByAttributeName(criteria.Predicate.Field.Name);
                var paramName = string.Format("parameter_{0}", paramCount++);

                string clause;

                if (criteria.Operator is ISpatialOperator)
                {
                    clause = this._spatialOperators[criteria.Operator.GetType()].Invoke(criteria.Value as IGeometry,
                                                                                        attr.FieldName, paramName);
                }
                else
                {
                    clause = this._operators[criteria.Operator.GetType()].Invoke(attr.FieldName, paramName);    
                }

                translated.Parameters.Add(new SqlParam()
                                              {
                                                  FieldName = attr.FieldName,
                                                  ParamName = paramName,
                                                  DataType = attr.PropertyInfo.PropertyType,
                                                  Value = criteria.Value
                                              });

                sql.Append(clause);
                sql.Append(" ");

                if (connectors.MoveNext())
                {
                    var conn = connectors.Current;
                    sql.Append(this._connectors[conn.GetType()].Invoke());
                    sql.Append(" ");
                }
            }

            translated.SqlText = sql.ToString();

            return translated;
        }

        #endregion

        #region Private Methods
        
        /// <summary>
        /// Map operators
        /// </summary>
        /// <returns>Operators</returns>
        private static IDictionary<Type, Func<string, string, string>> MapOperators()
        {
            var map = new Dictionary<Type, Func<string, string, string>>();

            map.Add(typeof(Equal), TranslateToSqlMethods.TranslateOperatorEqual);
            map.Add(typeof(NotEqual), TranslateToSqlMethods.TranslateOperatorNotEqual);
            map.Add(typeof(GreaterThan), TranslateToSqlMethods.TranslateOperatorGreaterThan);

            return map;
        }

        /// <summary>
        /// Map operators
        /// </summary>
        /// <returns>Operators</returns>
        private static IDictionary<Type, Func<IGeometry, string, string, string>> MapSpatialOperators()
        {
            var map = new Dictionary<Type, Func<IGeometry, string, string, string>>();

            map.Add(typeof(Within), TranslateToSqlMethods.TranslateOperatorWithin);

            return map;
        }

        /// <summary>
        /// Map connectors
        /// </summary>
        /// <returns>Connectors</returns>
        private static IDictionary<Type, Func<string>> MapConnectors()
        {
            var map = new Dictionary<Type, Func<string>>();

            map.Add(typeof(And), TranslateToSqlMethods.TranslateConnectorAnd);
            map.Add(typeof(Or), TranslateToSqlMethods.TranslateConnectorOr);

            return map;
        }

        #endregion

    }
}
