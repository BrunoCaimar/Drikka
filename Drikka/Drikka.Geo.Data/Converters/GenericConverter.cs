using Drikka.Geo.Data.Contracts.TypesMapping;

namespace Drikka.Geo.Data.Converters
{
    /// <summary>
    /// Generic converter, used for unneeded convertion
    /// </summary>
    public class GenericConverter : ITypeConverter
    {
        /// <summary>
        /// Read data from db and return object typed
        /// </summary>
        /// <param name="data">data from db</param>
        /// <returns>Object typed data</returns>
        public object Read(object data)
        {
            return data;
        }

        /// <summary>
        /// Write data onto db
        /// </summary>
        /// <param name="value">object data</param>
        /// <returns>Db typed data</returns>
        public object Write(object value)
        {
            return value;
        }
    }
}
