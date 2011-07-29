using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Drikka.Geo.Data.Contracts.Mapping;
using Manon.Comparer;
using Manon.Extensions.Expressions;

namespace Drikka.Geo.Data.Mapping
{
    /// <summary>
    /// Mapper
    /// </summary>
    /// <typeparam name="T">Generic Type - Domain</typeparam>
    public abstract class Mapper<T> : IMapping
    {
        #region Fields
        
        /// <summary>
        /// Dictionary to search by field name
        /// </summary>
        private readonly IDictionary<string, IAttribute> _byFieldName;

        /// <summary>
        /// Dictionary to search by attribute name
        /// </summary>
        private readonly IDictionary<string, IAttribute> _byPropName;

        #endregion

        #region Properties

        /// <summary>
        /// Mapped type
        /// </summary>
        public Type MappedType
        {
            get { return typeof (T); }
        }

        /// <summary>
        /// All Mappings
        /// </summary>
        public IList<IAttribute> AllMapping { get; private set; }

        /// <summary>
        /// AttributesMappings
        /// </summary>
        public IList<IAttribute> IdentifiersMapping { get; private set; }

        /// <summary>
        /// AttributesMappings
        /// </summary>
        public IList<IAttribute> AttributesMappings { get; private set; }

        /// <summary>
        /// Table Name
        /// </summary>
        public string TableName { get; private set; }

        #endregion

        #region IMapping Implementation

        /// <summary>
        /// Execute mapping for a guiven type
        /// </summary>
        public abstract void ExecuteMapping();

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        protected Mapper()
        {
            this.AttributesMappings = new List<IAttribute>();
            this.IdentifiersMapping = new List<IAttribute>();
            this.AllMapping = new List<IAttribute>();

            this._byFieldName = new SortedDictionary<string, IAttribute>(new CaseInsensitiveComparer());
            this._byPropName = new SortedDictionary<string, IAttribute>(new CaseInsensitiveComparer());
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get mapping attribute by field name
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <returns>Attribute</returns>
        public IAttribute GetByFieldName(string fieldName)
        {
            return this._byFieldName[fieldName];
        }

        /// <summary>
        /// Get mapping attribute by attribute name
        /// </summary>
        /// <param name="attributeName">attribute name</param>
        /// <returns>Attribute</returns>
        public IAttribute GetByAttributeName(string attributeName)
        {
            return this._byFieldName[attributeName];
        }

        /// <summary>
        /// Map a Property to a field
        /// </summary>
        /// <param name="expression">Property expression</param>
        /// <param name="fieldName">Field</param>
        public Attribute MapAttribute(Expression<Func<T, object >> expression, string fieldName)
        {
            if (this._byFieldName.ContainsKey(fieldName))
            {
                throw new DuplicateNameException(string.Format("The field {0} is already mapped.", fieldName));
            }

            var attrib = new Attribute(expression.GetPropoertyInfo(), fieldName);
            AddAttribute(attrib.PropertyInfo.Name, fieldName, attrib);

            return attrib;
        }

        /// <summary>
        /// Map a Property to a id field
        /// </summary>
        /// <param name="expression">Property expression</param>
        /// <param name="fieldName">Field</param>
        public SingleIdentifier MapIdentifier(Expression<Func<T, object >> expression, string fieldName)
        {
            if (this._byFieldName.ContainsKey(fieldName))
            {
                throw new DuplicateNameException(string.Format("The field {0} is already mapped.", fieldName));
            }

            var identifier = new SingleIdentifier(expression.GetPropoertyInfo(), fieldName);
            AddIdentifier(identifier.PropertyInfo.Name, fieldName, identifier);

            return identifier;
        }

        /// <summary>
        /// Set the table name
        /// </summary>
        /// <param name="tableName">Table Name</param>
        public void SetTableName(string tableName)
        {
            this.TableName = tableName;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Add a attribute
        /// </summary>
        /// <param name="attribName">Attribute name</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="attribute">Attribute</param>
        private void AddAttribute(string attribName, string fieldName, IAttribute attribute)
        {
            this._byFieldName.Add(fieldName, attribute);
            this._byPropName.Add(attribName, attribute);

            this.AllMapping.Add(attribute);
            this.AttributesMappings.Add(attribute);
        }

        /// <summary>
        /// Add a identifier
        /// </summary>
        /// <param name="attribName">Attribute name</param>
        /// <param name="fieldName">Field name</param>
        /// <param name="attribute">Attribute</param>
        private void AddIdentifier(string attribName, string fieldName, IAttribute attribute)
        {
            this._byFieldName.Add(fieldName, attribute);
            this._byPropName.Add(attribName, attribute);

            this.AllMapping.Add(attribute);
            this.IdentifiersMapping.Add(attribute);
        }

        #endregion
    }
}
