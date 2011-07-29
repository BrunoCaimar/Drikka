using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Drikka.Geo.Tests.Common.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drikka.Geo.Data.Query.Tests
{
    [TestClass]
    public class QueryExtensionMethodsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var query = new Query<Person>();
            var a = query.Where(x => x.Name).Equal("Alaor").And(x => x.Age).GreaterThan(18).And(x => x.Id).NotEqual(0);

        }
    }
}
