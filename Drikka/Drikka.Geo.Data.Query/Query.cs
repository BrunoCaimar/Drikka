using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drikka.Geo.Data.Query
{
    public class Query<T> : IQuery<T>
    {
        public IList<ICriteria<T>> Criterias { get; set; }

        public Query()
        {
            this.Criterias = new List<ICriteria<T>>();
        }
    }
}
