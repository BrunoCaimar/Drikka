using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Drikka.Geo.Data.Contracts.ExecutionPlan;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.TypesMapping;

namespace Drikka.Geo.Data.ExecutionPlan
{
    /// <summary>
    /// Delete execution plan
    /// </summary>
    public class DeletePlan : IOperationPlan
    {
        #region Fields

        /// <summary>
        /// Type mapping
        /// </summary>
        private readonly IMapping _mapping;

        /// <summary>
        /// Container of types
        /// </summary>
        private readonly ITypeRegister _typeRegister;

        /// <summary>
        /// Text for insert command
        /// </summary>
        private readonly string _text;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapping">Type mapping</param>
        /// <param name="typeRegister">Container</param>
        public DeletePlan(IMapping mapping, ITypeRegister typeRegister)
        {
            this._mapping = mapping;
            this._typeRegister = typeRegister;
            this._text = this.GetDeleteText();
        }

        #endregion

        #region IOperationPlan Implementation

        /// <summary>
        /// Create Plan Parameters
        /// </summary>
        /// <returns>Plan Parameters</returns>
        public IPlanParameters CreatePlanParameter(Func<IDbDataParameter> parameterFactory, object domain)
        {
            var list = new List<IDbDataParameter>();

            foreach (var attribute in this._mapping.IdentifiersMapping)
            {
                var map = this._typeRegister.Get(attribute.PropertyInfo.PropertyType);

                var param = parameterFactory();

                param.Direction = ParameterDirection.Input;
                param.ParameterName = string.Format("@{0}", attribute.FieldName);
                param.DbType = map.DbType;
                param.Value = map.Converter.Write(attribute.PropertyInfo.GetValue(
                    domain, BindingFlags.GetProperty, null, null, CultureInfo.InvariantCulture));

                list.Add(param);
            }

            return new PlanParameters(this._text, list);
        }       
       
        #endregion

        #region Private Methods

        /// <summary>
        /// Get the delete text
        /// </summary>
        /// <returns>Delete Text</returns>
        private string GetDeleteText()
        {
            var text = new StringBuilder();
            text.Append("DELETE FROM ");
            text.Append(this._mapping.TableName);
            text.Append(" WHERE ");

            var names = this._mapping.IdentifiersMapping.Select(attribute => attribute.FieldName).ToList();
            var @params = names.Select(x => string.Format("{0} = @{0}", x)).ToList();
            text.Append(string.Join(", ", @params));

            return text.ToString();
        }

        #endregion

        
    }
}
