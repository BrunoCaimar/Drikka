using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Drikka.Geo.Data.Mapping.Tests.Unit.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void TestMethod1()
        {
            //var person = new Person();
            var mapper = new Mapper<Person>();
            mapper.MapAttribute(x => x.Name, "Nome");
        }
    }
}
