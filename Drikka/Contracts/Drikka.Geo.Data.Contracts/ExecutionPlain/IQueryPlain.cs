using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Contracts.ExecutionPlain
{
    public interface IQueryPlain
    {
        /// <summary>
        /// Get command text
        /// </summary>
        /// <returns>Insert command text</returns>
        string GetText();

        /// <summary>
        /// Get command text
        /// </summary>
        /// <returns>Insert command text</returns>
        string GetText<T>(IQuery<T> query);
    }
}
