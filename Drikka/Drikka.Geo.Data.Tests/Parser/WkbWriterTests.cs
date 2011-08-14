using System.Text;
using Drikka.Geo.Data.Parsers;
using Drikka.Geo.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drikka.Geo.Data.Tests.Parser
{
    [TestClass]
    public class WkbWriterTests
    {
        [TestMethod]
        public void Parse_Test()
        {
            var linear = new LinearRing();
            linear.Vertices.Add(new MapPoint(3, 5));
            linear.Vertices.Add(new MapPoint(7, 5));
            linear.Vertices.Add(new MapPoint(7, 3));
            linear.Vertices.Add(new MapPoint(3, 3));
            linear.Vertices.Add(new MapPoint(3, 5));
            
            var polygon = new Polygon();
            polygon.Rings.Add(linear);

            var writer = new WkbWriter();
            var result = writer.Parse(polygon);

            const string data = "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\b@\0\0\0\0\0\0@\0\0\0\0\0\0@\0\0\0\0\0\0@\0\0\0\0\0\0@\0\0\0\0\0\0\b@\0\0\0\0\0\0\b@\0\0\0\0\0\0\b@\0\0\0\0\0\0\b@\0\0\0\0\0\0@";

            var encoder = new UTF8Encoding();
            var strings = encoder.GetString(result);

            Assert.AreEqual(data, strings);
        }
    }
}
