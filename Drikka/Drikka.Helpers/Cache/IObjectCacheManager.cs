using System;
using System.Collections.Generic;
using System.Reflection;
using Natalie.Caches;

namespace Drikka.Helpers.Cache
{
    /// <summary>
    /// Cache manager
    /// </summary>
    public interface IObjectCacheManager
    {
        /// <summary>
        /// Setup the cache for a type
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="caches">Methods Caches</param>
        void SetupCache(Type type, IDictionary<MethodInfo, ICache<Object>> caches);

        /// <summary>
        /// Get the cache
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="methodInfo">Method</param>
        /// <returns>Method Cache</returns>
        ICache<object> GetCache(Type type, MethodInfo methodInfo);

        /// <summary>
        /// Indicate if the type has cache
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>True if has</returns>
        bool HasCachedMethods(Type type);

        /// <summary>
        /// Get all method cache for a type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>List of Methods</returns>
        IList<MethodInfo> GetCachedMethods(Type type);
    }
}
