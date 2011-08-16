using System.Collections.Generic;
using System.Linq;
using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Geometry
{
    /// <summary>
    /// Polygon
    /// </summary>
    public class Polygon : Geometry, IPolygon
    {
        #region Fields
        
        /// <summary>
        /// Envelope
        /// </summary>
        private IEnvelope _envelope;

        #endregion

        #region Properties
        
        /// <summary>
        /// Envelope
        /// </summary>
        public override IEnvelope Envelope
        {
            get 
            {
                return this._envelope ?? (this._envelope = CreateEnvelope());
            }
        }

        /// <summary>
        /// Rings
        /// </summary>
        public IList<ILinearRing> Rings { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Polygon()
        {
            this.Rings = new List<ILinearRing>();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create the envelope
        /// </summary>
        /// <returns></returns>
        private IEnvelope CreateEnvelope()
        {
            var points = new List<IMapPoint>();

            foreach (var linearRing in Rings)
            {
                points.AddRange(linearRing.Vertices);
            }

            var maxX = points.Select(x => x.X).Max();
            var maxY = points.Select(x => x.Y).Max();

            var minX = points.Select(x => x.X).Min();
            var minY = points.Select(x => x.Y).Min();

            var envelope = new Envelope(maxX, maxY, minX, minY);

            return envelope;
        }

        #endregion
    }
}
