using System;

namespace Drikka.Geo.Data.Contracts.Binders
{
    /// <summary>
    /// Binder Manager
    /// </summary>
    public interface IBindManager
    {
        /// <summary>
        /// Get the binder for a type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Binder</returns>
        IBinder GetBinder(Type type);
    }
}
