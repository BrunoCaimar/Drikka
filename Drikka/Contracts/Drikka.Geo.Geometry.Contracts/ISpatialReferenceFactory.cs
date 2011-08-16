using System;

namespace Drikka.Geo.Geometry.Contracts
{
    /// <summary>
    /// Spatial reference factory
    /// </summary>
    public interface ISpatialReferenceFactory
    {
        /// <summary>
        /// Get the spatial reference for a type
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <returns>Spatial Reference</returns>
        ISpatialReference Get<T>();

        /// <summary>
        /// Get the spatial reference for a type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Spatial Reference</returns>
        ISpatialReference Get(Type type);
    }
}
