using System.Collections;
using System.Collections.Generic;
using Drikka.Geo.Data.Contracts.Repository;
using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Geometry
{
    /// <summary>
    /// FeatureSet
    /// </summary>
    /// <typeparam name="T">Feature Type</typeparam>
    public class FeatureSet<T> : IFeatureSet<T> where T : AbstractFeature
    {
        #region Fields

        /// <summary>
        /// Data repository
        /// </summary>
        private readonly IDomainRepository<T> _repository;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="domainRepository">Data repository</param>
        public FeatureSet(IDomainRepository<T> domainRepository)
        {
            this._repository = domainRepository;
        }

        #endregion

        #region IFeatureSet Implementation

        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return this._repository.GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        #endregion

        /// <summary>
        /// Get domain by id
        /// </summary>
        /// <param name="id">Domain id</param>
        /// <returns></returns>
        public T Get(uint id)
        {
            return this._repository.Get(id);
        }

        /// <summary>
        /// Save domain
        /// </summary>
        /// <param name="domain">Domain</param>
        public void Save(T domain)
        {
            this._repository.Save(domain);
        }

        /// <summary>
        /// Delete domain
        /// </summary>
        /// <param name="domain"></param>
        public void Delete(T domain)
        {
            this._repository.Delete(domain);
        }

        #endregion

    }
}
