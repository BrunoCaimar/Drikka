namespace Drikka.Geo.Geometry.Contracts
{
    /// <summary>
    /// Geometry
    /// </summary>
    public interface IGeometry
    {
        /// <summary>
        /// Spatial Reference
        /// </summary>
        ISpatialReference SpatialReference { get; }

        /// <summary>
        /// Envelope
        /// </summary>
        IEnvelope Envelope { get; }
    }
}
