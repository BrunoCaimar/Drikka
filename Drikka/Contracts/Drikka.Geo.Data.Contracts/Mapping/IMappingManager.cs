using System;
using System.Reflection;

namespace Drikka.Geo.Data.Contracts.Mapping
{
    /// <summary>
    /// Manager mapping
    /// </summary>
    public interface IMappingManager
    {
        /// <summary>
        /// Register new mapping for a type
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="mapping">Mapping</param>
        void Register(Type type, IMapping mapping);

        /// <summary>
        /// Get maping for a type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Mapping</returns>
        IMapping GetMapping(Type type);

        /// <summary>
        /// Load mappings from assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        void LoadFromAssembly(Assembly assembly);
    }
}
