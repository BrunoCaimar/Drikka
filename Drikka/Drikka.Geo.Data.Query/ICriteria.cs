
using System.Reflection;
using Drikka.Geo.Data.Query.Operators;

namespace Drikka.Geo.Data.Query
{
    public interface ICriteria<T>
    {
        PropertyInfo Field { get; }

        IOperator Operator { get; set; }

        object Value { get; set; }
    }
}
