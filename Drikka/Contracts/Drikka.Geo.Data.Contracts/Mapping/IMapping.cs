using System;
using System.Collections.Generic;

namespace Drikka.Geo.Data.Contracts.Mapping
{
    /// <summary>
    /// Mapping a domain
    /// </summary>
    public interface IMapping
    {
        /// <summary>
        /// Type Mapped
        /// </summary>
        Type MappedType { get; }

        /// <summary>
        /// All Mappings (Attributes and Indentfiers)
        /// </summary>
        IList<IAttribute> AllMapping { get; }

        /// <summary>
        /// AttributesMappings
        /// </summary>
        IList<IAttribute> IdentifiersMapping { get; }

        /// <summary>
        /// AttributesMappings
        /// </summary>
        IList<IAttribute> AttributesMappings { get; }

        /// <summary>
        /// Table Name
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// Set the table name
        /// </summary>
        /// <param name="tableName">Table Name</param>
        void SetTableName(string tableName);

        /// <summary>
        /// Execute mapping for a guiven type
        /// </summary>
        void ExecuteMapping();

        /// <summary>
        /// Get mapping attribute by field name
        /// </summary>
        /// <param name="fieldName">field name</param>
        /// <returns>Attribute</returns>
        IAttribute GetByFieldName(string fieldName);

        /// <summary>
        /// Get mapping attribute by attribute name
        /// </summary>
        /// <param name="attributeName">attribute name</param>
        /// <returns>Attribute</returns>
        IAttribute GetByAttributeName(string attributeName);
    }
}
