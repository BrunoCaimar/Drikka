using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        private IDictionary<string, IAttribute> _allMapping;

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
        public IDictionary<string, IAttribute> AllMapping 
        { 
            get
            {
                if (this._allMapping.Count != this.AttributesMappings.Count + this.IdentifiersMapping.Count)
                {
                    this._allMapping.Clear();
                    AttributesMappings.Concat(IdentifiersMapping).ToList().ForEach(x => this._allMapping.Add(x));
                }
                
                return this._allMapping;
            } 
        }

        /// <summary>
        /// AttributesMappings
        /// </summary>
        public IDictionary<string, IAttribute> IdentifiersMapping { get; private set; }

        /// <summary>
        /// AttributesMappings
        /// </summary>
        public IDictionary<string, IAttribute> AttributesMappings { get; private set; }

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
            this.AttributesMappings = new SortedDictionary<string, IAttribute>(new CaseInsensitiveComparer());
            this.IdentifiersMapping = new SortedDictionary<string, IAttribute>(new CaseInsensitiveComparer());
            this._allMapping = new SortedDictionary<string, IAttribute>(new CaseInsensitiveComparer());
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Map a Property to a field
        /// </summary>
        /// <param name="expression">Property expression</param>
        /// <param name="fieldName">Field</param>
        public Attribute MapAttribute(Expression<Func<T, object >> expression, string fieldName)
        {
            if (AttributesMappings.ContainsKey(fieldName))
            {
                throw new DuplicateNameException(string.Format("The field {0} is already mapped.", fieldName));
            }

            var attrib = new Attribute(expression.GetPropoertyInfo(), fieldName);
            AttributesMappings.Add(fieldName, attrib);

            return attrib;
        }

        /// <summary>
        /// Map a Property to a id field
        /// </summary>
        /// <param name="expression">Property expression</param>
        /// <param name="fieldName">Field</param>
        public SingleIdentifier MapIdentifier(Expression<Func<T, object >> expression, string fieldName)
        {
            if (IdentifiersMapping.ContainsKey(fieldName))
            {
                throw new DuplicateNameException(string.Format("The field {0} is already mapped.", fieldName));
            }

            var identifier = new SingleIdentifier(expression.GetPropoertyInfo(), fieldName);
            IdentifiersMapping.Add(fieldName, identifier);

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
    }
}
