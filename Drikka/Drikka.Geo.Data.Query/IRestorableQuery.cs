using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Query
{
    /// <summary>
    /// Restore the query root
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRestorableQuery<T>
    {
        /// <summary>
        /// Restore the query root
        /// </summary>
        IQuery<T> RootQuery { get; }
    }
}
