using System;
using Ninject;
using Ninject.Components;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Advice;
using Ninject.Extensions.Interception.Planning.Directives;
using Ninject.Extensions.Interception.Registry;
using Ninject.Planning;
using Ninject.Planning.Strategies;

namespace Drikka.Helpers.Cache
{
    /// <summary>
    /// Strategy to apply interception
    /// </summary>
    public class ObjectCachePlanningStrategy : NinjectComponent, IPlanningStrategy
    {
        #region Fields

        /// <summary>
        /// Advice factory
        /// </summary>
        private readonly IAdviceFactory _adviceFactory;

        /// <summary>
        /// Advice register
        /// </summary>
        private readonly IAdviceRegistry _adviceRegistry;

        /// <summary>
        /// Ninject Kernel
        /// </summary>
        private readonly IKernel _kernel;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="adviceFactory">Advice Factory</param>
        /// <param name="adviceRegistry">Advice Register</param>
        /// <param name="kernel">Ninject Kernel</param>
        public ObjectCachePlanningStrategy(IAdviceFactory adviceFactory, IAdviceRegistry adviceRegistry, IKernel kernel)
        {
            this._adviceFactory = adviceFactory;
            this._adviceRegistry = adviceRegistry;
            this._kernel = kernel;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Execute the plan strategy
        /// </summary>
        /// <param name="plan">Plan</param>
        public void Execute(IPlan plan)
        {
            var manager = this._kernel.Get<IObjectCacheManager>();

            if (!manager.HasCachedMethods(plan.Type))
            {
                return;
            }
            
            var methods = manager.GetCachedMethods(plan.Type);

            foreach (var method in methods)
            {
                var advice = this._adviceFactory.Create(method);
                var cache = manager.GetCache(plan.Type, method);
                var methodCache = typeof (MethodCache);
                var cacheMethod = (IInterceptor)Activator.CreateInstance(methodCache, cache);

                advice.Callback = request => cacheMethod;
                this._adviceRegistry.Register(advice);

                if (!plan.Has<ProxyDirective>())
                {
                    plan.Add(new ProxyDirective());
                }
            }
        }

        #endregion

    }
}
