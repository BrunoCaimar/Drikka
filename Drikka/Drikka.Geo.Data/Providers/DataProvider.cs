using System.Data;
using Drikka.Geo.Data.Contracts.Provider;

namespace Drikka.Geo.Data.Providers
{
    public class DataProvider : IDataProvider
    {
        #region Fields

        /// <summary>
        /// Connection
        /// </summary>
        private readonly IDbConnection _connection;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">Connection</param>
        public DataProvider(IDbConnection connection)
        {
            this._connection = connection;
        }

        #endregion

        #region IDataProvider Implementation

        /// <summary>
        /// Create a new command
        /// </summary>
        /// <returns>IDbCommand</returns>
        public IDbCommand CreateCommand()
        {
            return this._connection.CreateCommand();
        }

        /// <summary>
        /// Open connection
        /// </summary>
        public void OpenConnection()
        {
            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.Open();                
            }
        }

        /// <summary>
        /// Close connection
        /// </summary>
        public void CloseConnection()
        {
            if (this._connection.State != ConnectionState.Closed)
            {
                this._connection.Close();                
            }
        }

        /// <summary>
        /// Begin new transaction
        /// </summary>
        /// <returns>IDbTransaction</returns>
        public IDbTransaction BeginTransaction()
        {
            return this._connection.BeginTransaction(IsolationLevel.Unspecified);
        }

        #endregion

    }
}
