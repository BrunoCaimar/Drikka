using System;
using System.Data;

namespace Drikka.Geo.Data.Contracts.TypesMapping
{
    /// <summary>
    /// TypeMapping converts the object type to a db type
    /// </summary>
    public interface ITypeMapping
    {
        /// <summary>
        /// Database type
        /// </summary>
        DbType DbType { get; }

        /// <summary>
        /// Object type
        /// </summary>
        Type MappedType { get; }

        /// <summary>
        /// Converter to converte between object and bd type
        /// </summary>
        ITypeConverter Converter { get; }
    }
}
