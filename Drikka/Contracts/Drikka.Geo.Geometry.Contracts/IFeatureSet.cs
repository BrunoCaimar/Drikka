using System.Collections.Generic;
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Geometry.Contracts
{
    /// <summary>
    /// Feature Set
    /// </summary>
    /// <typeparam name="T">Domain Type</typeparam>
    public interface IFeatureSet<T> : IEnumerable<T> where T : IFeature
    {
        /// <summary>
        /// Get domain by id
        /// </summary>
        /// <param name="id">Domain id</param>
        /// <returns></returns>
        T Get(int id);

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

        /// <summary>
        /// Execute query statement for domain
        /// </summary>
        /// <typeparam name="T">Domain type</typeparam>
        /// <param name="query">Query</param>
        /// <returns>List of domains</returns>
        IList<T> Query(IQuery<T> query);
    }
}
