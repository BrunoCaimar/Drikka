using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Repositories;
using Drikka.Geo.Data.Tests.Mappings;
using Drikka.Geo.Data.TypesMapping;
using Drikka.Geo.Tests.Common.Entities;
using Drikka.Geo.Tests.Common.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Drikka.Geo.Data.Query;

namespace Drikka.Geo.Data.Tests.Repositories
{
    [TestClass]
    public class GenericDomainsRepositoryTests
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
        public void GetAll_Tests()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var executer = kernel.Resolve<GenericDomainsRepository>();
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(PersonMap).Assembly);
            types.MapTypes();

            var result = executer.GetAll(typeof (Person));

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Count, 0);
        }

        [TestMethod]
        [DeploymentItem("TestsDatabase.sdf")]
        public void Query_Tests()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var executer = kernel.Resolve<GenericDomainsRepository>();
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(PersonMap).Assembly);
            types.MapTypes();

            var query = new Query<Person>();
            query.Where(x => x.Name).Equal("Alaor").And(x => x.Age).Equal(28).And(x => x.Id).GreaterThan(0);

            var result = executer.Query(query);

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Count, 0);
        }

        [TestMethod]
        [DeploymentItem("TestsDatabase.sdf")]
        public void Get_Tests()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var executer = kernel.Resolve<GenericDomainsRepository>();
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(CityMap).Assembly);
            types.MapTypes();

            var result = executer.Get(typeof(City), 1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(City));
        }

        [TestMethod]
        [DeploymentItem("TestsDatabase.sdf")]
        public void Delete_Tests()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var executer = kernel.Resolve<GenericDomainsRepository>();
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(CityMap).Assembly);
            types.MapTypes();

            var result = executer.Get(typeof(City), 1);
            Assert.IsNotNull(result);

            executer.Delete(result);

            result = executer.Get(typeof(City), 1);

            Assert.IsNull(result);
        }
    }
}
