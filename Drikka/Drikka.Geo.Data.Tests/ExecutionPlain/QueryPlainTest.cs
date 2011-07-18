using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Drikka.Geo.Data.ExecutionPlain;
using Drikka.Geo.Data.Tests.Mappings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace Drikka.Geo.Data.Tests.ExecutionPlain
{
    [TestClass]
    public class QueryPlainTest
    {
        [TestMethod]
        public void GetText_Returns_SelectText()
        {
            var mapping = new PersonMap();
            mapping.ExecuteMapping();

            var select = new QueryPlain(mapping);

            select.GetText().ToUpper().Should().Be("SELECT AGE, NAME, ID FROM PERSON");
        }
    }
}
