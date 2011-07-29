using System;
using System.IO;
using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Data.Parsers
{
    /// <summary>
    /// Well Known Binary Reader
    /// </summary>
    public class WkbReader
    {
        #region Fields
        
        /// <summary>
        /// Geometry Factory
        /// </summary>
        private readonly IGeometryFactory _geometryFactory;

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="geometryFactory">Geometry Factory</param>
        public WkbReader(IGeometryFactory geometryFactory)
        {
            this._geometryFactory = geometryFactory;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Parse the byte array to a geometry
        /// </summary>
        /// <param name="bytes">Byte array</param>
        /// <returns>IGeometry</returns>
        public IGeometry Parse(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                using (var reader = new BinaryReader(ms))
                {
                    return Parse(reader);
                }
            }
        }

        /// <summary>
        /// Parse the stream to a geometry
        /// </summary>
        /// <param name="reader">Stream</param>
        /// <returns>IGeometry</returns>
        public IGeometry Parse(BinaryReader reader)
        {
            var byteOrder = (WkbByteOrder)reader.ReadByte();

            var type = (WkbGeometryTypes)ReadUInt32(reader, byteOrder);

            switch (type)
            {
                case WkbGeometryTypes.WkbPoint:
                    return CreateMapPoint(reader, byteOrder);

                case WkbGeometryTypes.WkbLineString:
                    return CreateLineString(reader, byteOrder);

                case WkbGeometryTypes.WkbPolygon:
                    return CreatePolygon(reader, byteOrder);
                
                default:
                        throw new NotSupportedException(string.Format("Geometry type '{0}' not supported", type));
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create a MapPoint
        /// </summary>
        /// <param name="reader">Stream</param>
        /// <param name="byteOrder">Byte order</param>
        /// <returns>IMapPoint</returns>
        private IMapPoint CreateMapPoint(BinaryReader reader, WkbByteOrder byteOrder)
        {
            var x = ReadDouble(reader, byteOrder);
            var y = ReadDouble(reader, byteOrder);

            var point = this._geometryFactory.CreateMapPoint(x, y);

            return point;
        }

        /// <summary>
        /// Create a LineString
        /// </summary>
        /// <param name="reader">Stream</param>
        /// <param name="byteOrder">Byte order</param>
        /// <returns>ILineString</returns>
        private ILineString CreateLineString(BinaryReader reader, WkbByteOrder byteOrder)
        {
            var line = this._geometryFactory.CreateLinestring();

            var numVertices = (int)ReadUInt32(reader, byteOrder);

            for (int i = 0; i < numVertices; i++)
            {
                line.Vertices.Add(this.CreateMapPoint(reader, byteOrder));
            }
            
            return line;
        }

        /// <summary>
        /// Create a Polygon
        /// </summary>
        /// <param name="reader">Stream</param>
        /// <param name="byteOrder">Byte order</param>
        /// <returns>IPolygon</returns>
        private IPolygon CreatePolygon(BinaryReader reader, WkbByteOrder byteOrder)
        {
            var poly = this._geometryFactory.CreatePolygon();

            var numRings = (int)ReadUInt32(reader, byteOrder);

            for (int i = 0; i < numRings; i++)
            {
                poly.Rings.Add(this.CreateLinearRing(reader, byteOrder));
            }

            return poly;
        }

        /// <summary>
        /// Create a LinearRing
        /// </summary>
        /// <param name="reader">Stream</param>
        /// <param name="byteOrder">Byte order</param>
        /// <returns>ILinearRing</returns>
        private ILinearRing CreateLinearRing(BinaryReader reader, WkbByteOrder byteOrder)
        {
            var line = this._geometryFactory.CreateLinearRing();

            var numVertices = (int)ReadUInt32(reader, byteOrder);

            for (int i = 0; i < numVertices; i++)
            {
                line.Vertices.Add(this.CreateMapPoint(reader, byteOrder));
            }

            return line;
        }

        #endregion

        #region Private Static Methods
        
        /// <summary>
        /// Read uint value from reader
        /// </summary>
        /// <param name="reader">Stream Reader</param>
        /// <param name="byteOrder">Byte order</param>
        /// <returns>Uint value</returns>
        private static uint ReadUInt32(BinaryReader reader, WkbByteOrder byteOrder)
        {
            if (byteOrder == WkbByteOrder.Xdr)
            {
                byte[] bytes = BitConverter.GetBytes(reader.ReadUInt32());
                Array.Reverse(bytes);
                return BitConverter.ToUInt32(bytes, 0);
            }
            
            if (byteOrder == WkbByteOrder.Ndr)
            {
                return reader.ReadUInt32();
            }
            
            throw new ArgumentException("Byte order not recognized");
        }

        /// <summary>
        /// Read double value from reader
        /// </summary>
        /// <param name="reader">Stream Reader</param>
        /// <param name="byteOrder">Byte order</param>
        /// <returns>Double value</returns>
        private static double ReadDouble(BinaryReader reader, WkbByteOrder byteOrder)
        {
            if (byteOrder == WkbByteOrder.Xdr)
            {
                byte[] bytes = BitConverter.GetBytes(reader.ReadDouble());
                Array.Reverse(bytes);
                return BitConverter.ToDouble(bytes, 0);
            }

            if (byteOrder == WkbByteOrder.Ndr)
            {
                return reader.ReadDouble();                
            }
            
            throw new ArgumentException("Byte order not recognized");
        }

        #endregion
    }
}
