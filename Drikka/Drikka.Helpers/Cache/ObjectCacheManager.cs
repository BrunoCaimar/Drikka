using System;
using System.Collections.Generic;
using System.Reflection;
using Natalie.Caches;
using System.Linq;

namespace Drikka.Helpers.Cache
{
    /// <summary>
    /// Cache manager
    /// </summary>
    public class ObjectCacheManager : IObjectCacheManager
    {
        #region Fields
        
        /// <summary>
        /// Caches for methods
        /// </summary>
        private readonly IDictionary<Type, IDictionary<MethodInfo, ICache<Object>>> _caches;

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ObjectCacheManager()
        {
            this._caches = new Dictionary<Type, IDictionary<MethodInfo, ICache<object>>>();
        }

        #endregion

        #region IObjectCacheManager Implementation

        /// <summary>
        /// Setup the cache for a type
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="caches">Methods Caches</param>
        public virtual void SetupCache(Type type, IDictionary<MethodInfo, ICache<Object>> caches)
        {
            this._caches.Add(type, caches);
        }
        
        /// <summary>
        /// Get the cache
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="methodInfo">Method</param>
        /// <returns>Method Cache</returns>
        public virtual ICache<object > GetCache(Type type, MethodInfo methodInfo)
        {
            IDictionary<MethodInfo, ICache<Object>> result;

            if (!this._caches.TryGetValue(type, out result))
            {
                throw new KeyNotFoundException(string.Format("The type {0} does not exists in cache.", type.FullName));
            }

            ICache<object > cache;

            if (!result.TryGetValue(methodInfo, out cache))
            {
                throw new KeyNotFoundException(string.Format("The method {0} does not exists in cache.", methodInfo.Name));
            }

            return cache;
        }

        /// <summary>
        /// Indicate if the type has cache
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>True if has</returns>
        public bool HasCachedMethods(Type type)
        {
            return this._caches.ContainsKey(type);
        }

        /// <summary>
        /// Get all method cache for a type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>List of Methods</returns>
        public IList<MethodInfo> GetCachedMethods(Type type)
        {
            IDictionary<MethodInfo, ICache<Object>> result;

            if (!this._caches.TryGetValue(type, out result))
            {
                throw new KeyNotFoundException(string.Format("The type {0} does not exists in cache.", type.FullName));
            }

            var methods = result.Select(x => x.Key).ToList();

            return methods;
        }

        #endregion

    }
}
