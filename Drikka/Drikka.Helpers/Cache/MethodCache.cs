using System;
using Natalie.Caches;
using Natalie.Keys;
using Ninject.Extensions.Interception;

namespace Drikka.Helpers.Cache
{
    public class MethodCache : IInterceptor
    {
        #region Fields
        
        /// <summary>
        /// Cache for a method invocation
        /// </summary>
        private readonly ICache<object> _cache;

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cache">Cache</param>
        public MethodCache(ICache<object> cache)
        {
            this._cache = cache;
        }

        #endregion

        #region IInterceptor Implementation
        
        /// <summary>
        /// Interceptor
        /// </summary>
        /// <param name="invocation">Method invocation</param>
        public void Intercept(IInvocation invocation)
        {
            var key = new CacheKey(invocation.Request.Arguments);

            if (this._cache.Contais(key))
            {
                invocation.ReturnValue = this._cache.Get(key);

                return;
            }

            invocation.Proceed();
            
            this._cache.Put(key, invocation.ReturnValue);
        }

        #endregion
    }
}
