using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Drikka.Geo.Data.Contracts.Query;
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

        #region Properties

        /// <summary>
        /// Spatial Reference
        /// </summary>
        public ISpatialReference SpatialReference { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="domainRepository">Data repository</param>
        /// <param name="spatialReference">Spatial Reference</param>
        public FeatureSet(IDomainRepository<T> domainRepository, ISpatialReference spatialReference)
        {
            this._repository = domainRepository;
            this.SpatialReference = spatialReference;
        }

        #endregion

        #region IFeatureSet Implementation

        #region IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return this._repository.GetAll().Select(this.SetSpatialReference).GetEnumerator();
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
        public T Get(int id)
        {
            T result = this._repository.Get(id);
            
            this.SetSpatialReference(result);
            
            return result;
        }

        /// <summary>
        /// Save domain
        /// </summary>
        /// <param name="domain">Domain</param>
        public void Save(T domain)
        {
            domain = this._repository.Save(domain);
            this.SetSpatialReference(domain);
        }

        /// <summary>
        /// Delete domain
        /// </summary>
        /// <param name="domain"></param>
        public void Delete(T domain)
        {
            this._repository.Delete(domain);
        }

        /// <summary>
        /// Execute query statement for domain
        /// </summary>
        /// <typeparam name="T">Domain type</typeparam>
        /// <param name="query">Query</param>
        /// <returns>List of domains</returns>
        public IList<T> Query(IQuery<T> query)
        {
            return this._repository.Query(query).Select(this.SetSpatialReference).ToList();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Set the spatial reference
        /// </summary>
        /// <param name="feature">Feature</param>
        private T SetSpatialReference(T feature)
        {
            var geometry = (Geometry)feature.Geometry;
            geometry.SpatialReference = this.SpatialReference;

            return feature;
        }

        #endregion

    }
}
