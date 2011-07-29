using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Geometry
{
    /// <summary>
    /// Envelope
    /// </summary>
    public class Envelope : IEnvelope
    {
        #region Properties
        
        /// <summary>
        /// Max X value
        /// </summary>
        public double MaxX { get; set; }

        /// <summary>
        /// Max Y value
        /// </summary>
        public double MaxY { get; set; }

        /// <summary>
        /// Min X value
        /// </summary>
        public double MinX { get; set; }

        /// <summary>
        /// Min Y value
        /// </summary>
        public double MinY { get; set; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Envelope()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxX">Max X</param>
        /// <param name="maxY">Max Y</param>
        /// <param name="minX">Min X</param>
        /// <param name="minY">Min Y</param>
        public Envelope(double maxX, double maxY, double minX, double minY)
        {
            this.MaxX = maxX;
            this.MaxY = maxY;
            this.MinX = minX;
            this.MinY = minY;
        }

        #endregion
    }
}
