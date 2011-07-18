
using System.Collections.Generic;

namespace Drikka.Geo.Data.Query
{
    public interface IQuery<T>
    {
        IList<ICriteria<T>> Criterias { get; set; }
    }
}
