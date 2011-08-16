using System.Collections.Generic;
using Drikka.Common;
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
            var srid = new SpatialReference(4326);
            var arg = new KeyValuePair<string, object>("spatialReference", srid);

            var featureSet = IoC.Resolve<IFeatureSet<T>>(arg);

            return featureSet;
        }

        

    }
}
