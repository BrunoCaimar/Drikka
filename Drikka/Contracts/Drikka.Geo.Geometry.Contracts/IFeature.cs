namespace Drikka.Geo.Geometry.Contracts
{
    /// <summary>
    /// Represents a feature
    /// </summary>
    public interface IFeature
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        uint Id { get; }

        /// <summary>
        /// Geometry
        /// </summary>
        IGeometry Geometry { get; }
    
    }
}
