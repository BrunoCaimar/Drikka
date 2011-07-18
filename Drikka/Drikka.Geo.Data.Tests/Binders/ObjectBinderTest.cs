using System.Data;
using Drikka.Geo.Data.Binders;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.TypesMapping;
using Drikka.Geo.Data.Tests.Mappings;
using Drikka.Geo.Data.TypesMapping;
using Drikka.Geo.Tests.Common.Entities;
using Drikka.Geo.Tests.Common.IoC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharpTestsEx;

namespace Drikka.Geo.Data.Tests.Binders
{
    [TestClass]
    public class ObjectBinderTest
    {
        [TestMethod]
        public void Bind_Should_Bind_Domain_Object()
        {
            var kernel = new NinjectContainer();
            var maps = kernel.Resolve<IMappingManager>();
            var types = kernel.Resolve<BasicTypesMap>();
            var person = new Person();

            maps.LoadFromAssembly(typeof(PersonMap).Assembly);
            types.MapTypes();

            var record = new Mock<IDataReader>();
            record.SetupGet(x => x.FieldCount).Returns(3);
            record.Setup(x => x.GetName(0)).Returns("NAME");
            record.Setup(x => x.GetName(1)).Returns("AGE");
            record.Setup(x => x.GetName(2)).Returns("ID");
            record.Setup(x => x.GetValue(0)).Returns("Alaor");
            record.Setup(x => x.GetValue(1)).Returns(28);
            record.Setup(x => x.GetValue(2)).Returns(1);

            var mapping = maps.GetMapping(person.GetType());
            var register = kernel.Resolve<ITypeRegister>();
            var binder = new ObjectBinder(mapping, register);

            binder.Bind(record.Object, person);

            person.Name.Should().Be("Alaor");
            person.Id.Should().Be(1);
            person.Age.Should().Be(28);
        }
    }
}
