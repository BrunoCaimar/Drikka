using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Postgre.Query;
using Drikka.Geo.Data.Postgre.Tests.Mappings;
using Drikka.Geo.Data.Query;
using Drikka.Geo.Tests.Common.Entities;
using Drikka.Geo.Tests.Common.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace Drikka.Geo.Data.Postgre.Tests
{
    [TestClass]
    public class QueryTranslatorTests
    {
        [TestMethod]
        public void Simple_Query_Translate()
        {
            var container = new NinjectContainer();
            var map = container.Resolve<IMappingManager>();
            var mapper = new PersonMap();
            mapper.ExecuteMapping();
            map.Register(mapper.MappedType, mapper);

            var query = new Query<Person>();
            query.Where(x => x.Name).Equal("Alaor").And(x => x.Age).GreaterThan(18).And(x => x.Id).NotEqual(0);

            var translator = new QueryTranslator(map);
            var result = translator.Translate(query);
            
            result.SqlText.Trim().ToUpper().Should().Be("NAME = @PARAMETER_0 AND AGE > @PARAMETER_1 AND ID <> @PARAMETER_2");
            result.Parameters.Count.Should().Be(3);
        }
    }
}
