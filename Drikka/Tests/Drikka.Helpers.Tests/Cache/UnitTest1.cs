using System.Collections.Generic;
using System.Reflection;
using Drikka.Helpers.Cache;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Natalie.Caches;
using Ninject;
using Ninject.Planning.Strategies;

namespace Drikka.Helpers.Tests.Cache
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var kernel = new StandardKernel(new Module());
            kernel.Components.Add<IPlanningStrategy, ObjectCachePlanningStrategy>();

            var manager = kernel.Get<IObjectCacheManager>();
            var method = typeof(Descriptor).GetMethod("GetMetadata");
            var cache = new DictionaryCache<object>();

            var keyval = new Dictionary<MethodInfo, ICache<object>>();
            keyval.Add(method, cache);

            manager.SetupCache(typeof (Descriptor), keyval);

            var descriptor = kernel.Get<IDescriptor>();

            var data = descriptor.GetMetadata(typeof (int));

            Assert.AreEqual(descriptor.Count, 1);

            var data2 = descriptor.GetMetadata(typeof(int));

            Assert.AreEqual(descriptor.Count, 1);
        }
    }
}
