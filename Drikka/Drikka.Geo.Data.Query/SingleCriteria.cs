using Drikka.Geo.Data.Contracts.Query;
using Drikka.Geo.Data.Query.Operators;

namespace Drikka.Geo.Data.Query
{
    public class SingleCriteria<T> : ICriteria<T>, IRestorableQuery<T>
    {
        private readonly IQuery<T> _rootQuery;

        public SingleCriteria(IQuery<T> rootQuery, IPredicate<T> predicate, IOperator @operator, object value)
        {
            this._rootQuery = rootQuery;
            this.Predicate = predicate;
            this.Operator = @operator;
            this.Value = value;
        }

        public IPredicate<T> Predicate { get; private set; }

        public IOperator Operator { get; private set; }

        public object Value { get; private set; }

        public IQuery<T> RootQuery
        {
            get { return this._rootQuery; }
        }
    }
}
