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
        IDictionary<string, IAttribute> AllMapping { get; }

        /// <summary>
        /// AttributesMappings
        /// </summary>
        IDictionary<string, IAttribute> IdentifiersMapping { get; }

        /// <summary>
        /// AttributesMappings
        /// </summary>
        IDictionary<string, IAttribute> AttributesMappings { get; }

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
    }
}
