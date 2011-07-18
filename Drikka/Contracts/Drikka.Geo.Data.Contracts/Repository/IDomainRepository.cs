using System;
using System.Collections;

namespace Drikka.Geo.Data.Contracts.Repository
{
    /// <summary>
    /// Generic repository for generic domains
    /// </summary>
    public interface IDomainRepository
    {
        /// <summary>
        /// Save the domain object
        /// </summary>
        /// <param name="domain">domain value</param>
        /// <returns>Saved object</returns>
        object Save(object domain);

        /// <summary>
        /// Update the domain object
        /// </summary>
        /// <param name="domain">domain value</param>
        /// <returns>Updated object</returns>
        object Update(object domain);

        /// <summary>
        /// Delete the domain object
        /// </summary>
        /// <param name="domain">domain value</param>
        void Delete(object domain);

        /// <summary>
        /// Get the domain object by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>domain object</returns>
        object Get(object id);

        /// <summary>
        /// Get all domains of passed type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>List of all domains of a passed type</returns>
        IList GetAll(Type type);
    }
}
