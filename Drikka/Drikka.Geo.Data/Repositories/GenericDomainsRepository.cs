using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Drikka.Geo.Data.Contracts.Binders;
using Drikka.Geo.Data.Contracts.ExecutionPlain;
using Drikka.Geo.Data.Contracts.Provider;
using Drikka.Geo.Data.Contracts.Query;
using Drikka.Geo.Data.Contracts.Repository;

namespace Drikka.Geo.Data.Repositories
{
    public class GenericDomainsRepository : IDomainRepository
    {
        #region Fields

        /// <summary>
        /// Data Provider
        /// </summary>
        private readonly IDataProvider _dataProvider;

        /// <summary>
        /// Execute Plain Manager
        /// </summary>
        private readonly IExecutionPlainManager _plainManager;

        /// <summary>
        /// Object Bind Manager
        /// </summary>
        private readonly IBindManager _bindManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataProvider">DataProvider</param>
        /// <param name="plainManager">Execute Plain Manager</param>
        /// <param name="bindManager">Bind Manager</param>
        public GenericDomainsRepository(IDataProvider dataProvider, IExecutionPlainManager plainManager, IBindManager bindManager)
        {
            this._dataProvider = dataProvider;
            this._plainManager = plainManager;
            this._bindManager = bindManager;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Execute insert statement for domain
        /// </summary>
        /// <param name="domain">Domain</param>
        public object Save(object domain)
        {
            throw new NotImplementedException();

            //var plain = this._plainManager.GetInsertPlain(domain.GetType());
            //var cmd = this._dataProvider.CreateCommand();

            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = plain.GetText();
            //plain.GetParameters(cmd, domain).ForEach(x => cmd.Parameters.Add(x));

            //this._dataProvider.OpenConnection();

            //using (var trans = this._dataProvider.BeginTransaction())
            //{
            //    try
            //    {
            //        cmd.Prepare();

            //        cmd.ExecuteNonQuery();

            //        trans.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        trans.Rollback();
            //        throw;
            //    }
            //    finally
            //    {
            //        this._dataProvider.CloseConnection();
            //    }    
            //} 
        }

        /// <summary>
        /// Execute query statement
        /// </summary>
        /// <param name="type">Domain type</param>
        /// <returns>List of domains</returns>
        public IList GetAll(Type type)
        {
            var plain = this._plainManager.GetQueryPlain(type);

            return ExecuteQuery(plain.GetText(), type);
        }

        /// <summary>
        /// Execute query statement
        /// </summary>
        /// <param name="type">Domain type</param>
        /// <param name="id">Object Id</param>
        /// <returns>List of domains</returns>
        public object Get(Type type, object id)
        {
            var plain = this._plainManager.GetQueryPlain(type);
            var cmd = this._dataProvider.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = plain.GetTextById();

            cmd.Parameters.Add(plain.GetParameter(cmd, id));

            return FirstOrDefault(ExecuteQuery(cmd, type));
        }

        public object Update(object domain)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete the domain
        /// </summary>
        /// <param name="domain">Domain</param>
        public void Delete(object domain)
        {
            var plain = this._plainManager.GetDeletePlain(domain.GetType());
            var cmd = this._dataProvider.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = plain.GetText();

            plain.GetParameters(cmd, domain).ForEach(x => cmd.Parameters.Add(x));

            this.ExecuteCommand(cmd);
        }

        /// <summary>
        /// Execute query statement for domain
        /// </summary>
        /// <typeparam name="T">Domain type</typeparam>
        /// <param name="query">Query</param>
        /// <returns>List of domains</returns>
        public IList Query<T>(IQuery<T> query)
        {
            var plain = this._plainManager.GetQueryPlain(query.QueriedType);

            return ExecuteQuery(plain.GetText(query), query.QueriedType);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Execute query
        /// </summary>
        /// <param name="sqlText">Query statement</param>
        /// <param name="type">Domain type</param>
        /// <returns>List of domains</returns>
        private IList ExecuteQuery(string sqlText, Type type)
        {
            var cmd = this._dataProvider.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlText;

            var list = ExecuteQuery(cmd, type);

            return list;
        }

        /// <summary>
        /// Execute query
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="type">Domain type</param>
        /// <returns>List of domains</returns>
        private IList ExecuteQuery(IDbCommand command, Type type)
        {
            var binder = this._bindManager.GetBinder(type);

            this._dataProvider.OpenConnection();
            command.Prepare();

            var list = new List<object>();

            using (var reader = command.ExecuteReader(CommandBehavior.Default))
            {
                while (reader.Read())
                {
                    var domain = Activator.CreateInstance(type);
                    binder.Bind(reader, domain);
                    list.Add(domain);
                }

                reader.Close();
            }

            this._dataProvider.CloseConnection();

            return list;
        }

        /// <summary>
        /// Execute a command
        /// </summary>
        /// <param name="cmd">Command</param>
        private void ExecuteCommand(IDbCommand cmd)
        {
            this._dataProvider.OpenConnection();

            using (var trans = this._dataProvider.BeginTransaction())
            {
                try
                {
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();

                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    this._dataProvider.CloseConnection();
                }
            }     
        }

        /// <summary>
        /// Return the first or default object
        /// </summary>
        /// <param name="list">List</param>
        /// <returns>value</returns>
        private static object FirstOrDefault(IList list)
        {
            if (list == null || list.Count == 0)
            {
                return null;
            }

            return list[0];
        }

        #endregion
    }
}
