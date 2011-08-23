using System;
using System.Data;
using Drikka.Geo.Data.Contracts.TypesMapping;
using Drikka.Geo.Data.Converters;
using Drikka.Geo.Geometry.Contracts;

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

        /// <summary>
        /// Geometry factory
        /// </summary>
        private readonly IGeometryFactory _geometryFactory;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="typeRegister">Register</param>
        /// <param name="geometryFactory">Geometry Factory</param>
        public BasicTypesMap(ITypeRegister typeRegister, IGeometryFactory geometryFactory)
        {
            this._typeRegister = typeRegister;
            this._geometryFactory = geometryFactory;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Execute mapping for baseic types
        /// </summary>
        public void MapTypes()
        {
            var wkbConverter = new WellKnownBinaryConverter(this._geometryFactory);
            var genericConverter = new GenericConverter();
            var int32Converter = new Int32Converter();

            var map = new TypeMap(DbType.Int32, typeof(uint), genericConverter);
            this._typeRegister.Set(map);

            map = new TypeMap(DbType.Int32, typeof(int), int32Converter);
            this._typeRegister.Set(map);

            map = new TypeMap(DbType.String, typeof(string), genericConverter);
            this._typeRegister.Set(map);

            map = new TypeMap(DbType.DateTime, typeof(DateTime), genericConverter);
            this._typeRegister.Set(map);

            map = new TypeMap(DbType.Binary, typeof(IMapPoint), wkbConverter);
            this._typeRegister.Set(map);

            map = new TypeMap(DbType.Binary, typeof(ILineString), wkbConverter);
            this._typeRegister.Set(map);

            map = new TypeMap(DbType.Binary, typeof(IPolygon), wkbConverter);
            this._typeRegister.Set(map);

            map = new TypeMap(DbType.Binary, typeof(IGeometry), wkbConverter);
            this._typeRegister.Set(map);
        }

        #endregion
    }
}
