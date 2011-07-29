using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Geometry
{
    /// <summary>
    /// MapPoint
    /// </summary>
    public class MapPoint : Geometry, IMapPoint
    {
        #region Fields
        
        /// <summary>
        /// Envelope
        /// </summary>
        private IEnvelope _envelope;

        #endregion

        #region Properties
        
        /// <summary>
        /// X part of coordinate
        /// </summary>
        public double X { get; private set; }

        /// <summary>
        /// Y part of coordinate
        /// </summary>
        public double Y { get; private set; }

        /// <summary>
        /// Envelope
        /// </summary>
        public override IEnvelope Envelope
        {
            get
            {
                return this._envelope ?? (this._envelope = new Envelope(this.X, this.Y, this.X, this.Y));
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public MapPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        #endregion

    }
}
