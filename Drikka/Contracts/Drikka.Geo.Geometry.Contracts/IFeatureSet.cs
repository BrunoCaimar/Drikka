using System.Collections.Generic;

namespace Drikka.Geo.Geometry.Contracts
{
    /// <summary>
    /// Feature Set
    /// </summary>
    /// <typeparam name="T">Domain Type</typeparam>
    public interface IFeatureSet<T> : IEnumerable<T>
    {
        /// <summary>
        /// Get domain by id
        /// </summary>
        /// <param name="id">Domain id</param>
        /// <returns></returns>
        T Get(uint id);

        /// <summary>
        /// Save domain
        /// </summary>
        /// <param name="domain">Domain</param>
        void Save(T domain);

        /// <summary>
        /// Delete domain
        /// </summary>
        /// <param name="domain"></param>
        void Delete(T domain);
    }
}
