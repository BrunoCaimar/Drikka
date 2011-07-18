using System.Data;

namespace Drikka.Geo.Data.Contracts.Provider
{
    /// <summary>
    /// Data Provider
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Create a new command
        /// </summary>
        /// <returns>IDbCommand</returns>
        IDbCommand CreateCommand();

        /// <summary>
        /// Open connection
        /// </summary>
        void OpenConnection();

        /// <summary>
        /// Close connection
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// Begin new transaction
        /// </summary>
        /// <returns>IDbTransaction</returns>
        IDbTransaction BeginTransaction();        
    }
}
