using System.Text;
using System.Linq;
using Drikka.Geo.Data.Parsers;
using Drikka.Geo.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drikka.Geo.Data.Tests.Parser
{
    [TestClass]
    public class WkbReaderTests
    {
        [TestMethod]
        public void Parse_Test()
        {
            var encoder = new UTF8Encoding();
            const string data = "\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0\b@\0\0\0\0\0\0@\0\0\0\0\0\0@\0\0\0\0\0\0@\0\0\0\0\0\0@\0\0\0\0\0\0\b@\0\0\0\0\0\0\b@\0\0\0\0\0\0\b@\0\0\0\0\0\0\b@\0\0\0\0\0\0@";

            var bytes = encoder.GetBytes(data);

            var factory = new GeometryFactory();
            var parser = new WkbReader(factory);
            var result = parser.Parse(bytes);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Polygon));

            var polygon = (Polygon) result;
            Assert.IsNotNull(polygon.Rings.FirstOrDefault());
            Assert.AreEqual(polygon.Rings.FirstOrDefault().Vertices.Count, 5);
        }
    }
}
