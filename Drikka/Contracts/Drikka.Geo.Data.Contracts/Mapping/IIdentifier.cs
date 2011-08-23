using System;

namespace Drikka.Geo.Data.Contracts.Mapping
{
    public interface IIdentifier : IAttribute
    {
        Type KeyGenerator { get; }
    }
}
