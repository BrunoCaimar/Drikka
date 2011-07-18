using System.Data;

namespace Drikka.Geo.Data.Contracts.Binders
{
    /// <summary>
    /// Object binder
    /// </summary>
    public interface IBinder
    {
        /// <summary>
        /// Bind the object with record data
        /// </summary>
        /// <param name="record">Record</param>
        /// <param name="domain">Domain object</param>
        void Bind(IDataRecord record, object domain);
    }
}
