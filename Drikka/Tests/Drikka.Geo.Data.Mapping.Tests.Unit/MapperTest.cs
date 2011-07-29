using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace Drikka.Geo.Data.Mapping.Tests.Unit
{
    /// <summary>
    /// Summary description for MapperTest
    /// </summary>
    [TestClass]
    public class MapperTest
    {
        public MapperTest()
        {
        }

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void MapAttribute_Must_Be_Case_Insensitive()
        {
            var mapper = new PersonMap();
            mapper.ExecuteMapping();

            mapper.Executing(x => x.GetByFieldName("NOME")).NotThrows();
        }

        [TestMethod]
        public void MapIdentifier_Must_Be_Case_Insensitive()
        {
            var mapper = new PersonMap();
            mapper.ExecuteMapping();

            mapper.Executing(x => x.GetByFieldName("id")).NotThrows();
        }
    }
}
