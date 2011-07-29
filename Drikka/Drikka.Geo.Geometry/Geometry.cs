using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Geometry
{
    /// <summary>
    /// Geometry
    /// </summary>
    public abstract class Geometry : IGeometry
    {
        /// <summary>
        /// Spatial Reference
        /// </summary>
        public ISpatialReference SpatialReference { get; set; }

        /// <summary>
        /// Envelope
        /// </summary>
        public abstract IEnvelope Envelope { get; }

    }
}
