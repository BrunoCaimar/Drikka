namespace Drikka.Geo.Data.Parsers
{
    /// <summary>
    /// Specifies the specific binary encoding (NDR or XDR) used for a geometry byte stream
    /// </summary>
    internal enum WkbByteOrder : byte
    {
        /// <summary>
        /// XDR (Big Endian) Encoding of Numeric Types
        /// </summary>
        Xdr = 0,

        /// <summary>
        /// NDR (Little Endian) Encoding of Numeric Types
        /// </summary>
        Ndr = 1
    }
}
