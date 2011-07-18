using System;
using System.Collections.Generic;
using Drikka.Geo.Data.Contracts.TypesMapping;

namespace Drikka.Geo.Data.TypesMapping
{
    /// <summary>
    /// Container to register type mapping
    /// </summary>
    public class TypeRegister : ITypeRegister
    {
        #region Field

        /// <summary>
        /// Dictionary as container
        /// </summary>
        private readonly IDictionary<Type, ITypeMapping> _mapping;

        #endregion

        #region Costructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public TypeRegister()
        {
            //this._mapping = new SortedDictionary<Type, ITypeMapping>();
            this._mapping = new Dictionary<Type, ITypeMapping>();
        }

        #endregion

        #region ITypeRegister Implementation
        
        /// <summary>
        /// Get the type mapping
        /// </summary>
        /// <param name="type">Type to recovery mapping</param>
        /// <returns>TypeMapping</returns>
        public ITypeMapping Get(Type type)
        {
            ITypeMapping mapping;

            if (!this._mapping.TryGetValue(type, out mapping))
            {
                throw new KeyNotFoundException(string.Format("The type {0} has not been mapped.", type.FullName));
            }

            return mapping;
        }

        /// <summary>
        /// Set the mapping for a type
        /// </summary>
        /// <param name="value">TypeMapping</param>
        public void Set(ITypeMapping value)
        {
            this._mapping.Add(value.MappedType, value);
        }

        #endregion
    }
}
