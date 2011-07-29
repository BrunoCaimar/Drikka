using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Geometry
{
    /// <summary>
    /// Spatial Reference
    /// </summary>
    public class SpatialReference : ISpatialReference
    {
        #region Properties
        
        /// <summary>
        /// Spatial reference ID
        /// </summary>
        public int Srid { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public SpatialReference()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="srid">Spatial reference ID</param>
        public SpatialReference(int srid)
        {
            this.Srid = srid;
        }

        #endregion

    }
}
