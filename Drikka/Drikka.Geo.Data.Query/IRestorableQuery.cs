
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Query
{
    public interface IRestorableQuery<T>
    {
        IQuery<T> RootQuery { get; }
    }
}
