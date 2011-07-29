using System.Reflection;

namespace Drikka.Geo.Data.Contracts.Query
{
    /// <summary>
    /// Query predicate
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public interface IPredicate<T>
    {
        /// <summary>
        /// Field
        /// </summary>
        PropertyInfo Field { get; }
    }
}
