﻿using System;
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
    /// plan to execute insert for a given type
    /// </summary>
    public class InsertPlan : IOperationPlan
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
        public InsertPlan(IMapping mapping, ITypeRegister typeRegister)
        {
            this._mapping = mapping;
            this._typeRegister = typeRegister;
            this._text = this.GetInsertText();
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

            foreach (var attribute in this._mapping.AttributesMappings)
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

       
        /// <summary>
        /// Get command text
        /// </summary>
        /// <returns>Insert command text</returns>
        private string GetInsertText()
        {
            var text = new StringBuilder();
            text.Append("INSERT INTO ");
            text.Append(this._mapping.TableName);
            text.Append(" (");

            var names = this._mapping.AttributesMappings.Select(attribute => attribute.FieldName).ToList();
            text.Append(string.Join(", ", names));

            text.Append(") VALUES (");

            var @params = names.Select(x => string.Format("@{0}", x)).ToList();
            text.Append(string.Join(", ", @params));

            text.Append(")");

            return text.ToString();
        }

        #endregion
        
    }
}
