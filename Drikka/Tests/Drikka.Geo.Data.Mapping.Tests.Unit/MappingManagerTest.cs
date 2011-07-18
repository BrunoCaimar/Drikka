using Drikka.Geo.Tests.Common.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drikka.Geo.Data.Mapping.Tests.Unit
{
    [TestClass]
    public class MappingManagerTest
    {
        [TestMethod]
        public void LoadFromAssembly_Should_Load_Mappings()
        {
            var assembly = typeof(PersonMap).Assembly;

            var manager = new MappingManager();
            manager.LoadFromAssembly(assembly);

            var map = manager.GetMapping(typeof(Person));
            Assert.IsNotNull(map);
        }
    }
}
