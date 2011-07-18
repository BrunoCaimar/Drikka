using System;
using System.Collections.Generic;
using System.Reflection;
using Drikka.Geo.Data.Contracts.Mapping;
using Manon.Extensions.Assemblies;

namespace Drikka.Geo.Data.Mapping
{
    /// <summary>
    /// Manager mapping
    /// </summary>
    public class MappingManager : IMappingManager
    {

        #region Fields

        /// <summary>
        /// Mappings
        /// </summary>
        private readonly IDictionary<Type, IMapping> _mapping;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MappingManager()
        {
            this._mapping = new SortedDictionary<Type, IMapping>();
        }

        #endregion

        #region IMappingManager Implementation

        /// <summary>
        /// Register new mapping for a type
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="mapping">Mapping</param>
        public void Register(Type type, IMapping mapping)
        {
            this._mapping.Add(type, mapping);
        }

        /// <summary>
        /// Get maping for a type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Mapping</returns>
        public IMapping GetMapping(Type type)
        {
            return this._mapping[type];
        }

        /// <summary>
        /// Load mappings from assembly
        /// </summary>
        /// <param name="assembly">Assembly</param>
        public void LoadFromAssembly(Assembly assembly)
        {
            var types = assembly.GetTypesImplements<IMapping>();

            foreach (var type in types)
            {
                var mapping = (IMapping)Activator.CreateInstance(type);
                mapping.ExecuteMapping();

                Register(mapping.MappedType, mapping);
            }
        }

        #endregion

    }
}
