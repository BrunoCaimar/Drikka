using System.Reflection;

namespace Drikka.Geo.Data.Contracts.Mapping
{
    /// <summary>
    /// Map attribute
    /// </summary>
    public interface IAttribute
    {
        /// <summary>
        /// Property Info
        /// </summary>
        PropertyInfo PropertyInfo { get; }

        /// <summary>
        /// Field Name
        /// </summary>
        string FieldName { get; }
    }
}
