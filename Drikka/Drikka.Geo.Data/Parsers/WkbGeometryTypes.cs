namespace Drikka.Geo.Data.Parsers
{
    /// <summary>
    /// Well known geometry types
    /// </summary>
    internal enum WkbGeometryTypes : uint
    {
        WkbPoint = 1,
        WkbLineString = 2,
        WkbPolygon = 3,
        WkbMultiPoint = 4,
        WkbMultiLineString = 5,
        WkbMultiPolygon = 6,
        WkbGeometryCollection = 7
    }
}
