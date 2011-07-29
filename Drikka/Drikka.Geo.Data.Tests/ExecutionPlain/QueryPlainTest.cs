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

            var select = new QueryPlain(mapping, null);

            select.GetText().ToUpper().Should().Be("SELECT ID, NAME, AGE FROM PERSON");
        }

        [TestMethod]
        public void GetText_Returns_SelectFormatedText()
        {
            var mapping = new FormatedPersonMap();
            mapping.ExecuteMapping();

            var select = new QueryPlain(mapping, null);

            select.GetText().ToUpper().Should().Be("SELECT ID, ASBINARY(NAME) AS NAME, AGE FROM PERSON");
        }
    }
}
