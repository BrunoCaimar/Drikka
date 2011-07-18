using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Drikka.Geo.Data.Query.Operators;

namespace Drikka.Geo.Data.Query
{
    public class SingleCriteria<T> : ICriteria<T>
    {
        private IQuery<T> _rootQuery;

        public SingleCriteria(IQuery<T> rootQuery, PropertyInfo field)
        {
            this._rootQuery = rootQuery;
            this.Field = field;
        }

        public PropertyInfo Field { get; private set; }

        public IOperator Operator { get; set; }

        public object Value { get; set; }
    }
}
