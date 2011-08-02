using System;
using System.Collections.Generic;
using System.Reflection;

namespace Drikka.Helpers.Tests.Cache
{
    public class Descriptor : IDescriptor
    {
        public virtual int Count { get; private set; }

        public virtual IList<PropertyInfo> GetMetadata(Type type)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.GetProperty);

            this.Count++;

            return props;
        }
    }
}
