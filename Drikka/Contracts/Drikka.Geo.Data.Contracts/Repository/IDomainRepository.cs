using System;
using System.Collections.Generic;
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Contracts.Repository
{
    /// <summary>
    /// Generic repository for generic domains
    /// </summary>
    public interface IDomainRepository<T>
    {
        /// <summary>
        /// Save the domain object
        /// </summary>
        /// <param name="domain">domain value</param>
        /// <returns>Saved object</returns>
        T Save(T domain);

        /// <summary>
        /// Update the domain object
        /// </summary>
        /// <param name="domain">domain value</param>
        /// <returns>Updated object</returns>
        T Update(T domain);

        /// <summary>
        /// Delete the domain object
        /// </summary>
        /// <param name="domain">domain value</param>
        void Delete(T domain);

        /// <summary>
        /// Get the domain object by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>domain object</returns>
        T Get(object id);

        /// <summary>
        /// Get all domains of passed type
        /// </summary>
        /// <returns>List of all domains of a passed type</returns>
        IList<T> GetAll();

        /// <summary>
        /// Execute query statement for domain
        /// </summary>
        /// <typeparam name="T">Domain type</typeparam>
        /// <param name="query">Query</param>
        /// <returns>List of domains</returns>
        IList<T> Query(IQuery<T> query);
    }
}
