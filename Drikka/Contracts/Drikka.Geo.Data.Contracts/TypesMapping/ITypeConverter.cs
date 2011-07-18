namespace Drikka.Geo.Data.Contracts.TypesMapping
{
    /// <summary>
    /// Convertion between object type and db type
    /// </summary>
    public interface ITypeConverter
    {
        /// <summary>
        /// Read data from db and return object typed
        /// </summary>
        /// <param name="data">data from db</param>
        /// <returns>Object typed data</returns>
        object Read(object data);

        /// <summary>
        /// Write data onto db
        /// </summary>
        /// <param name="value">object data</param>
        /// <returns>Db typed data</returns>
        object Write(object value);
    }
}
