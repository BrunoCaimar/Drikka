using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Geometry
{
    public class GeometryFactory : IGeometryFactory
    {
        public IMapPoint CreateMapPoint(double x, double y)
        {
            return new MapPoint(x, y);
        }

        public ILineString CreateLinestring()
        {
            return new LineString();
        }

        public IPolygon CreatePolygon()
        {
            return new Polygon();
        }

        public ILinearRing CreateLinearRing()
        {
            return new LinearRing();
        }
    }
}
