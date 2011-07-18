using System;
using Drikka.Geo.Common.Contracts;
using Ninject;

namespace Drikka.Geo.Tests.Common.IoC
{
    public class NinjectContainer : IContainerIoC
    {
        private readonly IKernel _kernel;

        public NinjectContainer()
        {
            this._kernel = new StandardKernel(new TestModule());
        }

        public T Resolve<T>()
        {
            return this._kernel.Get<T>();
        }

        public object Resolve(Type type)
        {
            return this._kernel.Get(type);
        }

        public object Resolve(string typeName)
        {
            return this._kernel.Get(Type.GetType(typeName));
        }
    }
}
