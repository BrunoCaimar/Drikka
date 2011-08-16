using System.Collections.Generic;

namespace Drikka.Geo.Data.Contracts.Sql
{
    /// <summary>
    /// Sql translation
    /// </summary>
    public interface ISqlTranslation
    {
        /// <summary>
        /// Sql Text
        /// </summary>
        string SqlText { get; }

        /// <summary>
        /// Parameters
        /// </summary>
        IList<ISqlParam> Parameters { get; }
    }
}
