using Drikka.Geo.Data.Contracts.Query;
using Drikka.Geo.Geometry.Contracts;

namespace Drikka.Geo.Data.Postgre.Query
{
    /// <summary>
    /// Translate functions
    /// </summary>
    public static class TranslateToSqlMethods
    {
        #region Operators

        public static string TranslateOperatorEqual(string field, string paramName)
        {
            return string.Format("{0} = @{1}", field, paramName);
        }

        public static string TranslateOperatorNotEqual(string field, string paramName)
        {
            return string.Format("{0} <> @{1}", field, paramName);
        }

        public static string TranslateOperatorGreaterThan(string field, string paramName)
        {
            return string.Format("{0} > @{1}", field, paramName);
        }

        #endregion

        #region Connectors

        public static string TranslateConnectorAnd()
        {
            return "AND";
        }

        public static string TranslateConnectorOr()
        {
            return "Or";
        }

        #endregion

        #region Spatial

        public static string TranslateOperatorWithin(IGeometry geometry, string field, string paramName)
        {
            return string.Format("WITHIN({0}, ST_GeomFromWKB(@{1}, {2}))", field, paramName, geometry.SpatialReference.Srid);
        }

        #endregion
    }
}
