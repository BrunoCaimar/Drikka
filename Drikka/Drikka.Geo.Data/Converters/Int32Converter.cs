using System;
using Drikka.Geo.Data.Contracts.TypesMapping;

namespace Drikka.Geo.Data.Converters
{
    /// <summary>
    /// Convertion for int32
    /// </summary>
    public class Int32Converter : ITypeConverter
    {
        /// <summary>
        /// Read data from db and return object typed
        /// </summary>
        /// <param name="data">data from db</param>
        /// <returns>Object typed data</returns>
        public object Read(object data)
        {
            return Convert.ToInt32(data);
        }

        /// <summary>
        /// Write data onto db
        /// </summary>
        /// <param name="value">object data</param>
        /// <returns>Db typed data</returns>
        public object Write(object value)
        {
            return Convert.ToInt32(value);
        }
    }
}
