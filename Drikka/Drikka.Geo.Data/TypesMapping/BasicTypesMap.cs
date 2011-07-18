using System;
using System.Data;
using Drikka.Geo.Data.Contracts.TypesMapping;
using Drikka.Geo.Data.Converters;

namespace Drikka.Geo.Data.TypesMapping
{
    /// <summary>
    /// Mapping for basics types
    /// </summary>
    public class BasicTypesMap
    {
        #region Fields

        /// <summary>
        /// Register
        /// </summary>
        private readonly ITypeRegister _typeRegister;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="typeRegister">Register</param>
        public BasicTypesMap(ITypeRegister typeRegister)
        {
            this._typeRegister = typeRegister;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Execute mapping for baseic types
        /// </summary>
        public void MapTypes()
        {
            var map = new TypeMap(DbType.Int32, typeof(int), new GenericConverter());
            this._typeRegister.Set(map);

            map = new TypeMap(DbType.String, typeof(string), new GenericConverter());
            this._typeRegister.Set(map);

            map = new TypeMap(DbType.DateTime, typeof(DateTime), new GenericConverter());
            this._typeRegister.Set(map);
        }

        #endregion
    }
}
