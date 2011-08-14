using Drikka.Geo.Data.Contracts.TypesMapping;
using Drikka.Geo.Data.Parsers;
using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Data.Converters
{
    class WellKnownBinaryConverter : ITypeConverter
    {
        #region Fields

        /// <summary>
        /// WkbReader
        /// </summary>
        private readonly WkbReader _reader;

        /// <summary>
        /// WkbWriter
        /// </summary>
        private readonly WkbWriter _writer;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="geometryFactory">Geometry Factory</param>
        public WellKnownBinaryConverter(IGeometryFactory geometryFactory)
        {
            this._reader = new WkbReader(geometryFactory);
            this._writer = new WkbWriter();
        }

        #endregion

        #region ITypeConverter Implementation

        /// <summary>
        /// Read data from db and return object typed
        /// </summary>
        /// <param name="data">data from db</param>
        /// <returns>Object typed data</returns>
        public object Read(object data)
        {
            return this._reader.Parse(data as byte[]);
        }

        /// <summary>
        /// Write data onto db
        /// </summary>
        /// <param name="value">object data</param>
        /// <returns>Db typed data</returns>
        public object Write(object value)
        {
            return this._writer.Parse(value as IGeometry);
        }

        #endregion

    }
}
