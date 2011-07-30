using System;
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Postgre.Query
{
    /// <summary>
    /// Translate functions
    /// </summary>
    public static class TranslateToSqlMethods
    {
        #region Operators

        public static string TranslateOperatorEqual(IOperator @operator, string field, object value)
        {
            if (value is string)
            {
                return string.Format("{0} = '{1}'", field, value);
            }

            if (value is DateTime)
            {
                return string.Format("{0} = '{1}'", field, value);
            }

            return string.Format("{0} = {1}", field, value);
        }

        public static string TranslateOperatorNotEqual(IOperator @operator, string field, object value)
        {
            if (value is string)
            {
                return string.Format("{0} <> '{1}'", field, value);
            }

            if (value is DateTime)
            {
                return string.Format("{0} <> '{1}'", field, value);
            }

            return string.Format("{0} <> {1}", field, value);
        }

        public static string TranslateOperatorGreaterThan(IOperator @operator, string field, object value)
        {
            if (value is string)
            {
                return string.Format("{0} > '{1}'", field, value);
            }

            if (value is DateTime)
            {
                return string.Format("{0} > '{1}'", field, value);
            }

            return string.Format("{0} > {1}", field, value);
        }

        #endregion

        #region Connectors

        public static string TranslateConnectorAnd(IConnector connector)
        {
            return "AND";
        }

        public static string TranslateConnectorOr(IConnector connector)
        {
            return "Or";
        }

        #endregion

    }
}
