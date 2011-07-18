using System;
using System.Data;
using Drikka.Geo.Data.Contracts.TypesMapping;

namespace Drikka.Geo.Data.TypesMapping
{
    /// <summary>
    /// TypeMapping converts the object type to a db type
    /// </summary>
    public class TypeMap : ITypeMapping
    {
        #region Properties

        /// <summary>
        /// Database type
        /// </summary>
        public DbType DbType { get; private set;}

        /// <summary>
        /// Object type
        /// </summary>
        public Type MappedType { get; private set; }

        /// <summary>
        /// Converter to converte between object and bd type
        /// </summary>
        public ITypeConverter Converter { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbType">Database type</param>
        /// <param name="mapped">Type mapped</param>
        /// <param name="converter">Convertion class</param>
        public TypeMap(DbType dbType, Type mapped, ITypeConverter converter)
        {
            this.DbType = dbType;
            this.MappedType = mapped;
            this.Converter = converter;
        }

        #endregion

    }
}
