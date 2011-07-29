using System.Collections.Generic;

namespace Drikka.Geo.Geometry.Contracts
{
    /// <summary>
    /// Polygon
    /// </summary>
    public interface IPolygon : IGeometry
    {
        /// <summary>
        /// Linear rings
        /// </summary>
        IList<ILinearRing> Rings { get; }
    }
}
