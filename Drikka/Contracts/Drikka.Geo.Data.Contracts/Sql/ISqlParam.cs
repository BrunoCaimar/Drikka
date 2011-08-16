using System;

namespace Drikka.Geo.Data.Contracts.Sql
{
    /// <summary>
    /// Sql parameter
    /// </summary>
    public interface ISqlParam
    {
        /// <summary>
        /// Field Name
        /// </summary>
        string FieldName { get; }

        /// <summary>
        /// Parameter Name
        /// </summary>
        string ParamName { get; }

        /// <summary>
        /// Data Type
        /// </summary>
        Type DataType { get; }

        /// <summary>
        /// Value
        /// </summary>
        object Value { get; }
    }
}
