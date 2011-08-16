using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Geometry
{
    /// <summary>
    /// Abstract feature
    /// </summary>
    public abstract class AbstractFeature : IFeature
    {
        #region IFeature Implementation
        
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Geometry
        /// </summary>
        public IGeometry Geometry { get; set; }

        #endregion
    }
}
