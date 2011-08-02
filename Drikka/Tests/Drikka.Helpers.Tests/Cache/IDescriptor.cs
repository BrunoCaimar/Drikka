using System;
using System.Collections.Generic;
using System.Reflection;

namespace Drikka.Helpers.Tests.Cache
{
    public interface IDescriptor
    {
        int Count { get; }

        IList<PropertyInfo> GetMetadata(Type type);
    }
}
