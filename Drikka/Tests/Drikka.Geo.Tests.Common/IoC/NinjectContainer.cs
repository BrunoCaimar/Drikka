using System;
using Drikka.Geo.Common.Contracts;
using Ninject;

namespace Drikka.Geo.Tests.Common.IoC
{
    /// <summary>
    /// Ninject IoC Container
    /// </summary>
    public class NinjectContainer : IContainerIoC
    {
        #region Fields

        /// <summary>
        /// Ninject Kernel
        /// </summary>
        private readonly IKernel _kernel;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public NinjectContainer()
        {
            this._kernel = new StandardKernel(new TestModule());
        }

        #endregion

        #region IContainerIoC Implementation
        
        /// <summary>
        /// Resolve dependencies for a Type
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Concrete Object</returns>
        public T Resolve<T>()
        {
            return this._kernel.Get<T>();
        }

        /// <summary>
        /// Resolve dependencies for a Type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Concrete Object</returns>
        public object Resolve(Type type)
        {
            return this._kernel.Get(type);
        }

        /// <summary>
        /// Resolve dependencies for a Type
        /// </summary>
        /// <param name="typeName">Type name</param>
        /// <returns>Concrete Object</returns>
        public object Resolve(string typeName)
        {
            return this._kernel.Get(Type.GetType(typeName));
        }

        #endregion
    }
}
