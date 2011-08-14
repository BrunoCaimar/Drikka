using System;
using System.IO;
using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Data.Parsers
{
    /// <summary>
    /// Well known binary writer
    /// </summary>
    public class WkbWriter
    {
        #region Public Methods

        /// <summary>
        /// Parse the geometry to byte array
        /// </summary>
        /// <param name="geometry">Geometry</param>
        /// <returns>Byte array</returns>
        public byte[] Parse(IGeometry geometry)
        {
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    bw.Write((byte)WkbByteOrder.Ndr);

                    WriteGeometry(geometry, bw, WkbByteOrder.Ndr);

                    return ms.ToArray();
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Write the geometry
        /// </summary>
        /// <param name="geometry">Geometry</param>
        /// <param name="writer">BinaryWriter</param>
        /// <param name="byteOrder">Byte order</param>
        private static void WriteGeometry(IGeometry geometry, BinaryWriter writer, WkbByteOrder byteOrder)
        {
            if (geometry is IMapPoint)
            {
                WriteUInt32((uint) WkbGeometryTypes.WkbPoint, writer, byteOrder);
                WriteMapPoint(geometry as IMapPoint, writer, byteOrder);
            }
            else if(geometry is ILinearRing)
            {
                WriteUInt32((uint)WkbGeometryTypes.WkbLineString, writer, byteOrder);
                WriteLineString(geometry as ILineString, writer, byteOrder);
            }
            else if(geometry is IPolygon)
            {
                WriteUInt32((uint)WkbGeometryTypes.WkbPolygon, writer, byteOrder);
                WritePolygon(geometry as IPolygon, writer, byteOrder);
            }
            else
            {
                throw new ArgumentOutOfRangeException("geometry", "Geometry not supported.");
            }
        }

        /// <summary> Write the geometry to stream
        /// </summary>
        /// <param name="geometry">Geometry</param>
        /// <param name="writer">BinaryWriter</param>
        /// <param name="byteOrder">Byte order</param>
        private static void WriteMapPoint(IMapPoint geometry, BinaryWriter writer, WkbByteOrder byteOrder)
        {
            WriteDouble(geometry.X, writer, byteOrder);
            WriteDouble(geometry.Y, writer, byteOrder);
        }

        /// <summary> Write the geometry to stream
        /// </summary>
        /// <param name="geometry">Geometry</param>
        /// <param name="writer">BinaryWriter</param>
        /// <param name="byteOrder">Byte order</param>
        private static void WriteLineString(ILineString geometry, BinaryWriter writer, WkbByteOrder byteOrder)
        {
            WriteUInt32((uint)geometry.Vertices.Count, writer, byteOrder);

            foreach (var mapPoint in geometry.Vertices)
            {
                WriteMapPoint(mapPoint, writer, byteOrder);
            }
        }

        /// <summary> Write the geometry to stream
        /// </summary>
        /// <param name="geometry">Geometry</param>
        /// <param name="writer">BinaryWriter</param>
        /// <param name="byteOrder">Byte order</param>
        private static void WritePolygon(IPolygon geometry, BinaryWriter writer, WkbByteOrder byteOrder)
        {
            WriteUInt32((uint)geometry.Rings.Count, writer, byteOrder);

            foreach (var linearRing in geometry.Rings)
            {
                WriteLinearRing(linearRing, writer, byteOrder);
            }
        }

        /// <summary> Write the geometry to stream
        /// </summary>
        /// <param name="geometry">Geometry</param>
        /// <param name="writer">BinaryWriter</param>
        /// <param name="byteOrder">Byte order</param>
        private static void WriteLinearRing(ILinearRing geometry, BinaryWriter writer, WkbByteOrder byteOrder)
        {
            WriteUInt32((uint)geometry.Vertices.Count, writer, byteOrder);

            foreach (var mapPoint in geometry.Vertices)
            {
                WriteMapPoint(mapPoint, writer, byteOrder);
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Writes an unsigned integer to the stream
        /// </summary>
        /// <param name="value">Value to write</param>
        /// <param name="writer">Binary Writer</param>
        /// <param name="byteOrder">byteorder</param>
        private static void WriteUInt32(UInt32 value, BinaryWriter writer, WkbByteOrder byteOrder)
        {
            if (byteOrder == WkbByteOrder.Xdr)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                Array.Reverse(bytes);
                writer.Write(BitConverter.ToUInt32(bytes, 0));
            }
            else
                writer.Write(value);
        }

        /// <summary>
        /// Writes a double to the stream
        /// </summary>
        /// <param name="value">Value to write</param>
        /// <param name="writer">Binary Writer</param>
        /// <param name="byteOrder">byteorder</param>
        private static void WriteDouble(double value, BinaryWriter writer, WkbByteOrder byteOrder)
        {
            if (byteOrder == WkbByteOrder.Xdr)
            {
                byte[] bytes = BitConverter.GetBytes(value);
                Array.Reverse(bytes);
                writer.Write(BitConverter.ToDouble(bytes, 0));
            }
            else
                writer.Write(value);
        }

        #endregion

    }
}
