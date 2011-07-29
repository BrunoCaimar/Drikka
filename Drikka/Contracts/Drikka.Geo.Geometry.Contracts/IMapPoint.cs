namespace Drikka.Geo.Geometry.Contracts
{
    /// <summary>
    /// Point
    /// </summary>
    public interface IMapPoint : IGeometry
    {
        /// <summary>
        /// X part of coordinate
        /// </summary>
        double X { get; }
        
        /// <summary>
        /// Y part of coordinate
        /// </summary>
        double Y { get; }
    }
}
