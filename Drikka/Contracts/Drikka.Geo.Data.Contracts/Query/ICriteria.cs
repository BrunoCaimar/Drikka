namespace Drikka.Geo.Data.Contracts.Query
{
    /// <summary>
    /// Query criteria
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public interface ICriteria<T>
    {
        /// <summary>
        /// Predicate of T
        /// </summary>
        IPredicate<T> Predicate { get; }

        /// <summary>
        /// Operator of criteria
        /// </summary>
        IOperator Operator { get; }

        /// <summary>
        /// Value of predicate
        /// </summary>
        object Value { get; }
    }
}
