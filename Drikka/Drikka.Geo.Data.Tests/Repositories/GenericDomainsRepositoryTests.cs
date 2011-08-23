using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Repositories;
using Drikka.Geo.Data.Tests.Mappings;
using Drikka.Geo.Data.TypesMapping;
using Drikka.Geo.Tests.Common.Entities;
using Drikka.Geo.Tests.Common.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Drikka.Geo.Data.Query;
using SharpTestsEx;

namespace Drikka.Geo.Data.Tests.Repositories
{
    [TestClass]
    public class GenericDomainsRepositoryTests
    {
        [TestMethod]
        [DeploymentItem("TestsDatabase.sdf")]
        public void InsertTests()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(PersonMap).Assembly);
            types.MapTypes();
            
            var executer = kernel.Resolve<GenericDomainsRepository<Person>>();
            var person = new Person { Age = 25,Id = 0, Name = "Alaor" };

            executer.Save(person);

            person.Id.Should().Not.Be(0);
        }

        [TestMethod]
        [DeploymentItem("TestsDatabase.sdf")]
        public void UpdateTests()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(PersonMap).Assembly);
            types.MapTypes();

            var executer = kernel.Resolve<GenericDomainsRepository<Person>>();
            var result = executer.Get(1);

            result.Name = "Novo Nome";
            executer.Update(result);

            result = executer.Get(1);

            result.Name.Should().Be("Novo Nome");
        }

        [TestMethod]
        [DeploymentItem("TestsDatabase.sdf")]
        public void GetAll_Tests()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(PersonMap).Assembly);
            types.MapTypes();

            var executer = kernel.Resolve<GenericDomainsRepository<Person>>();

            var result = executer.GetAll();

            Assert.IsNotNull(result);
            Assert.AreNotEqual(result.Count, 0);
        }

        [TestMethod]
        [DeploymentItem("TestsDatabase.sdf")]
        public void Query_Tests()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(PersonMap).Assembly);
            types.MapTypes();

            var executer = kernel.Resolve<GenericDomainsRepository<Person>>();

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
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(CityMap).Assembly);
            types.MapTypes();

            var executer = kernel.Resolve<GenericDomainsRepository<City>>();
            var result = executer.Get(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(City));
        }

        [TestMethod]
        [DeploymentItem("TestsDatabase.sdf")]
        public void Delete_Tests()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var types = kernel.Resolve<BasicTypesMap>();

            maps.LoadFromAssembly(typeof(CityMap).Assembly);
            types.MapTypes();

            var executer = kernel.Resolve<GenericDomainsRepository<City>>();

            var result = executer.Get(2);
            Assert.IsNotNull(result);

            executer.Delete(result);

            result = executer.Get(2);

            Assert.IsNull(result);
        }
    }
}
