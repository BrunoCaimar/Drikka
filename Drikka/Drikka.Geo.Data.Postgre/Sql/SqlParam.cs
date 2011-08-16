using System;
using Drikka.Geo.Data.Contracts.Sql;

namespace Drikka.Geo.Data.Postgre.Sql
{
    public class SqlParam : ISqlParam
    {
        /// <summary>
        /// Field Name
        /// </summary>
        public string FieldName { get; set;}

        /// <summary>
        /// Parameter Name
        /// </summary>
        public string ParamName{ get; set;}

        /// <summary>
        /// Data Type
        /// </summary>
        public Type DataType{ get; set;}

        /// <summary>
        /// Value
        /// </summary>
        public object Value{ get; set;}
    }
}
