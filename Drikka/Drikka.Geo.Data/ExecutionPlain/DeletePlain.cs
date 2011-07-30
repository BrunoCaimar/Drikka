using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Drikka.Geo.Data.Contracts.ExecutionPlain;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.TypesMapping;

namespace Drikka.Geo.Data.ExecutionPlain
{
    /// <summary>
    /// Delete execution plain
    /// </summary>
    public class DeletePlain : IOperationPlain
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
        public DeletePlain(IMapping mapping, ITypeRegister typeRegister)
        {
            this._mapping = mapping;
            this._typeRegister = typeRegister;
            this._text = this.GetDeleteText();
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Get command text
        /// </summary>
        /// <returns>Delete command text</returns>
        public string GetText()
        {
            return this._text;
        }

        /// <summary>
        /// Get parameters for a command
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="domain">Domain Object</param>
        /// <returns>List of parameters</returns>
        public List<IDataParameter> GetParameters(IDbCommand command, object domain)
        {
            var @params = this._mapping.IdentifiersMapping.Select(
                    attribute => CreateParameter(command, domain, attribute)).Cast<IDataParameter>().ToList();

            return @params;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create parameter
        /// </summary>
        /// <param name="command">DbCommand</param>
        /// <param name="domain">Domain</param>
        /// <param name="attribute">Attribute</param>
        /// <returns>DataParameter</returns>
        private IDbDataParameter CreateParameter(IDbCommand command, object domain, IAttribute attribute)
        {
            var map = this._typeRegister.Get(attribute.PropertyInfo.PropertyType);

            var param = command.CreateParameter();

            param.Direction = ParameterDirection.Input;
            param.ParameterName = string.Format("@{0}", attribute.FieldName);
            param.DbType = map.DbType;
            param.Value = map.Converter.Write(attribute.PropertyInfo.GetValue(
                domain, BindingFlags.GetProperty, null, null, CultureInfo.InvariantCulture));

            return param;
        }

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
