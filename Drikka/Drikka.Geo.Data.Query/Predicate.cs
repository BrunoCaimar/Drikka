using System.Reflection;
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Query
{
    public class Predicate<T> : IPredicate<T>, IRestorableQuery<T>
    {
        private readonly IQuery<T> _rootQuery;

        public PropertyInfo Field { get; private set; }
        
        public Predicate(IQuery<T> rootQuery, PropertyInfo field)
        {
            this._rootQuery = rootQuery;
            this.Field = field;
        }

        public IQuery<T> RootQuery
        {
            get { return this._rootQuery; }
        }
    }
}
