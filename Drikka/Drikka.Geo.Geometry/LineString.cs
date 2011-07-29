using System.Collections.Generic;
using System.Linq;
using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Geometry
{
    /// <summary>
    /// Line string
    /// </summary>
    public class LineString : Geometry, ILineString
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
        /// Points
        /// </summary>
        public IList<IMapPoint> Vertices { get; private set; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor
        /// </summary>
        public LineString()
        {
            this.Vertices = new List<IMapPoint>();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create the envelope
        /// </summary>
        /// <returns></returns>
        private IEnvelope CreateEnvelope()
        {
            var maxX = this.Vertices.Select(x => x.X).Max();
            var maxY = this.Vertices.Select(x => x.Y).Max();

            var minX = this.Vertices.Select(x => x.X).Min();
            var minY = this.Vertices.Select(x => x.Y).Min();

            var envelope = new Envelope(maxX, maxY, minX, minY);

            return envelope;
        }

        #endregion

    }
}
