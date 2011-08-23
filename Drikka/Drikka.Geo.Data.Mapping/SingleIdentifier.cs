using System;
using System.Reflection;
using Drikka.Geo.Data.Contracts.ExecutionPlan;
using Drikka.Geo.Data.Contracts.Mapping;

namespace Drikka.Geo.Data.Mapping
{
    /// <summary>
    /// Identifier
    /// </summary>
    public class SingleIdentifier : Attribute, IIdentifier
    {
        private Type _keygenType;

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

        public Type KeyGenerator
        {
            get 
            {
                if (this._keygenType == null)
                {
                    throw new Exception("Key generator not set.");
                }

                return this._keygenType;
            }
        }

        public SingleIdentifier SetKeyGenerator<T>() where T : IInsertKeygen
        {
            this._keygenType = typeof(T);

            return this;
        }
    }
}
