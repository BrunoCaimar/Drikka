using System.Collections.Generic;

namespace Drikka.Geo.Geometry.Contracts
{
    /// <summary>
    /// Linestring
    /// </summary>
    public interface ILineString : IGeometry
    {
        /// <summary>
        /// Points
        /// </summary>
        IList<IMapPoint> Vertices { get; }
    }
}
