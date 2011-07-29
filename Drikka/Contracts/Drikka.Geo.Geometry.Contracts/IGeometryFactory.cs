using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drikka.Geo.Geometry.Contracts
{
    public interface IGeometryFactory
    {
        IMapPoint CreateMapPoint(double x, double y);

        ILineString CreateLinestring();

        IPolygon CreatePolygon();

        ILinearRing CreateLinearRing();
    }
}
