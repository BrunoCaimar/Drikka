using System;
using System.Collections.Generic;
using System.Linq;
using Drikka.Geo.Common.Contracts;

namespace Drikka.Common
{
    /// <summary>
    /// IoC Container
    /// </summary>
    public static class IoC
    {

        #region Field

        /// <summary>
        /// Container
        /// </summary>
        private static IContainerIoC _container;

        #endregion

        #region Properties
        
        /// <summary>
        /// Container
        /// </summary>
        public static IContainerIoC Container
        {
            get
            {
                if (_container == null)
                {
                    throw new Exception("IoC Container not initialized.");
                }

                return _container;
            }
        }

        #endregion

        #region Initializer
        
        /// <summary>
        /// Initialize the container
        /// </summary>
        /// <param name="container">Container</param>
        public static void Initialize(IContainerIoC container)
        {
            _container = container;
        }

        #endregion

        #region Resolvers

        /// <summary>
        /// Resolve type implementation
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Object of T type</returns>
        public static T Resolve<T>(params KeyValuePair<string, object>[] args)
        {
            return Container.Resolve<T>(args);
        }

        /// <summary>
        /// Resolve type implementation
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Object of T type</returns>
        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// Resolve type implementation
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Object of type</returns>
        public static object Resolve(Type type)
        {
            return Container.Resolve(type);
        }

        /// <summary>
        /// Resolve type implementation
        /// </summary>
        /// <param name="typeName">Type name</param>
        /// <returns>Object of type</returns>
        public static object Resolve(string typeName)
        {
            return Container.Resolve(typeName);
        }

        #endregion

    }
}
