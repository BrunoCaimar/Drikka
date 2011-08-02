using Drikka.Helpers.Cache;
using Ninject.Modules;

namespace Drikka.Helpers.Tests.Cache
{
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<IDescriptor>().To<Descriptor>().InSingletonScope();
            Bind<IObjectCacheManager>().ToConstant(new ObjectCacheManager());
        }
    }
}
