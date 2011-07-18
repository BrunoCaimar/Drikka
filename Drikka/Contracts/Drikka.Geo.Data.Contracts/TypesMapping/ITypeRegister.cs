using System;

namespace Drikka.Geo.Data.Contracts.TypesMapping
{
    /// <summary>
    /// Container to register type mapping
    /// </summary>
    public interface ITypeRegister
    {
        /// <summary>
        /// Get the type mapping
        /// </summary>
        /// <param name="type">Type to recovery mapping</param>
        /// <returns>TypeMapping</returns>
        ITypeMapping Get(Type type);

        /// <summary>
        /// Set the mapping for a type
        /// </summary>
        /// <param name="value">TypeMapping</param>
        void Set(ITypeMapping value);
    }
}
