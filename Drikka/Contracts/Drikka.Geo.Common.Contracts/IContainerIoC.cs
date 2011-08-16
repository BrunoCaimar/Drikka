using System;
using System.Collections.Generic;

namespace Drikka.Geo.Common.Contracts
{
    /// <summary>
    /// Interface for IoC Container
    /// </summary>
    public interface IContainerIoC
    {
        /// <summary>
        /// Resolve type implementation
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Object of T type</returns>
        T Resolve<T>(params KeyValuePair<string, object>[] args);

        /// <summary>
        /// Resolve type implementation
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Object of T type</returns>
        T Resolve<T>();

        /// <summary>
        /// Resolve type implementation
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Object of type</returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolve type implementation
        /// </summary>
        /// <param name="typeName">Type name</param>
        /// <returns>Object of type</returns>
        object Resolve(string typeName);
    }
}
