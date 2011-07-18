using System.Reflection;

namespace Drikka.Geo.Data.Mapping
{
    /// <summary>
    /// Identifier
    /// </summary>
    public class SingleIdentifier : Attribute
    {
        #region Constructor

        /// <summary>
        /// Cnstructor
        /// </summary>
        /// <param name="propertyInfo">Property Info</param>
        /// <param name="fieldName">Field Name</param>
        public SingleIdentifier(PropertyInfo propertyInfo, string fieldName) 
            : base(propertyInfo, fieldName)
        { }

        #endregion

    }
}
