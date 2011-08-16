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
        int Id { get; }

        /// <summary>
        /// Geometry
        /// </summary>
        IGeometry Geometry { get; }
    
    }
}
