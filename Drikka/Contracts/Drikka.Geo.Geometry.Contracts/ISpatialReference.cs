namespace Drikka.Geo.Geometry.Contracts
{
    /// <summary>
    /// Spatial Reference
    /// </summary>
    public interface ISpatialReference
    {
        /// <summary>
        /// Spatial Reference ID
        /// </summary>
        int Srid { get; }
    }
}
