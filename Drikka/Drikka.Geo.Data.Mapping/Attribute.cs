using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Drikka.Geo.Data.Mapping
{
    public class Attribute
    {
        public PropertyInfo PropertyInfo { get; private set; }

        public string FieldName { get; private set; }

        public Attribute(PropertyInfo propertyInfo, string fieldName)
        {
            this.PropertyInfo = propertyInfo;
            this.FieldName = fieldName;
        }
    }
}
