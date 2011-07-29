using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Executers;
using Drikka.Geo.Data.Tests.Mappings;
using Drikka.Geo.Data.TypesMapping;
using Drikka.Geo.Tests.Common.Entities;
using Drikka.Geo.Tests.Common.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Drikka.Geo.Data.Query;

namespace Drikka.Geo.Data.Tests.Executers
{
    [TestClass]
    public class StatementExecuterTests
    {
        [TestMethod]
        [DeploymentItem("TestsDatabase.sdf")]
        public void InsertTests()
        {
            //var kernel = new NinjectContainer();
            //var maps = kernel.Resolve<IMappingManager>();
            //var executer = kernel.Resolve<StatementExecuter>();
            //var person = new Person {Age = 25, Id = 1, Name = "Alaor"};
            //var types = kernel.Resolve<BasicTypesMap>();

            //maps.LoadFromAssembly(typeof(PersonMap).Assembly);
            //types.MapTypes();

            //executer.Insert(person);

            //executer.Insert(person);
        }

        [TestMethod]
        [DeploymentItem("TestsDatabase.sdf")]
        public void QueryTests()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var executer = kernel.Resolve<StatementExecuter>();
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(PersonMap).Assembly);
            types.MapTypes();

            var result = executer.Query(typeof (Person));

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Count, 0);
        }

        [TestMethod]
        [DeploymentItem("TestsDatabase.sdf")]
        public void Query_With_Criteria_Tests()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var executer = kernel.Resolve<StatementExecuter>();
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(PersonMap).Assembly);
            types.MapTypes();

            var query = new Query<Person>();
            query.Where(x => x.Name).Equal("Alaor").And(x => x.Age).Equal(28).And(x => x.Id).GreaterThan(0);

            var result = executer.Query(query);

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Count, 0);
        }
    }
}
