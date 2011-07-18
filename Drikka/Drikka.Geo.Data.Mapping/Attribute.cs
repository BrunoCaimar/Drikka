using System.Reflection;
using Drikka.Geo.Data.Contracts.Mapping;

namespace Drikka.Geo.Data.Mapping
{
    /// <summary>
    /// Attribute
    /// </summary>
    public class Attribute : IAttribute
    {
        #region Properties

        /// <summary>
        /// Property Info
        /// </summary>
        public PropertyInfo PropertyInfo { get; private set; }

        /// <summary>
        /// Field Name
        /// </summary>
        public string FieldName { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyInfo">Property Info</param>
        /// <param name="fieldName">Field Name</param>
        public Attribute(PropertyInfo propertyInfo, string fieldName)
        {
            this.PropertyInfo = propertyInfo;
            this.FieldName = fieldName;
        }

        #endregion

    }
}
