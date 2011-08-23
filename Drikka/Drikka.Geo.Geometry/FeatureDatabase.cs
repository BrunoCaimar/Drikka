using System.Collections.Generic;
using Drikka.Common;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.Repository;
using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Geometry
{
    /// <summary>
    /// Feature Database
    /// </summary>
    public class FeatureDatabase : IFeatureDatabase
    {
        /// <summary>
        /// Get the FeatureSet
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <returns>FeatureSet</returns>
        public IFeatureSet<T> Get<T>() where T : IFeature
        {
            var srid = GetSpatialReference<T>();

            var arg = new KeyValuePair<string, object>("spatialReference", srid);

            var featureSet = IoC.Resolve<IFeatureSet<T>>(arg);

            return featureSet;
        }

        /// <summary>
        /// Get the spatial reference
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <returns>ISpatialReference</returns>
        public virtual ISpatialReference GetSpatialReference<T>()
        {
            var spfs = IoC.Resolve<IDomainRepository<SpatialReference>>();
            var mapper = IoC.Resolve<IMappingManager>();
            var mapping = mapper.GetMapping(typeof(T));
            var srid = spfs.Get(mapping.TableName.ToLower());

            return srid;
        }

    }
}
