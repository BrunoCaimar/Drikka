using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Drikka.Geo.Data.Contracts.Binders;
using Drikka.Geo.Data.Contracts.ExecutionPlan;
using Drikka.Geo.Data.Contracts.Provider;
using Drikka.Geo.Data.Contracts.Query;
using Drikka.Geo.Data.Contracts.Repository;

namespace Drikka.Geo.Data.Repositories
{
    public class GenericDomainsRepository<T> : IDomainRepository<T>
    {
        #region Fields

        /// <summary>
        /// Data Provider
        /// </summary>
        private readonly IDataProvider _dataProvider;

        /// <summary>
        /// Execute plan Manager
        /// </summary>
        private readonly IExecutionPlanManager _planManager;

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
        /// <param name="planManager">Execute plan Manager</param>
        /// <param name="bindManager">Bind Manager</param>
        public GenericDomainsRepository(IDataProvider dataProvider, IExecutionPlanManager planManager, IBindManager bindManager)
        {
            this._dataProvider = dataProvider;
            this._planManager = planManager;
            this._bindManager = bindManager;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Execute insert statement for domain
        /// </summary>
        /// <param name="domain">Domain</param>
        public T Save(T domain)
        {
            throw new NotImplementedException();

            //var plan = this._planManager.GetInsertplan(domain.GetType());
            //var cmd = this._dataProvider.CreateCommand();

            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = plan.GetText();
            //plan.GetParameters(cmd, domain).ForEach(x => cmd.Parameters.Add(x));

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
        public IList<T> GetAll()
        {
            var plan = this._planManager.GetQueryplan(typeof(T));

            return ExecuteQuery(plan.GetText());
        }

        /// <summary>
        /// Execute query statement
        /// </summary>
        /// <param name="type">Domain type</param>
        /// <param name="id">Object Id</param>
        /// <returns>List of domains</returns>
        public T Get(object id)
        {
            var plan = this._planManager.GetQueryplan(typeof(T));
            var cmd = this._dataProvider.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = plan.GetTextById();

            cmd.Parameters.Add(plan.GetParameter(cmd, id));

            return FirstOrDefault(ExecuteQuery(cmd));
        }

        public T Update(T domain)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete the domain
        /// </summary>
        /// <param name="domain">Domain</param>
        public void Delete(T domain)
        {
            var plan = this._planManager.GetDeleteplan(domain.GetType());
            var cmd = this._dataProvider.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = plan.GetText();

            plan.GetParameters(cmd, domain).ForEach(x => cmd.Parameters.Add(x));

            this.ExecuteCommand(cmd);
        }

        /// <summary>
        /// Execute query statement for domain
        /// </summary>
        /// <typeparam name="T">Domain type</typeparam>
        /// <param name="query">Query</param>
        /// <returns>List of domains</returns>
        public IList<T> Query(IQuery<T> query)
        {
            var plan = this._planManager.GetQueryplan(query.QueriedType);

            return ExecuteQuery(plan.GetText(query));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Execute query
        /// </summary>
        /// <param name="sqlText">Query statement</param>
        /// <returns>List of domains</returns>
        private IList<T> ExecuteQuery(string sqlText)
        {
            var cmd = this._dataProvider.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlText;

            var list = ExecuteQuery(cmd);

            return list;
        }

        /// <summary>
        /// Execute query
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="type">Domain type</param>
        /// <returns>List of domains</returns>
        private IList<T> ExecuteQuery(IDbCommand command)
        {
            var type = typeof (T);
            var binder = this._bindManager.GetBinder(type);

            this._dataProvider.OpenConnection();
            command.Prepare();

            var list = new List<T>();

            using (var reader = command.ExecuteReader(CommandBehavior.Default))
            {
                while (reader.Read())
                {
                    var domain = (T)Activator.CreateInstance(type);
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
        private static T FirstOrDefault(IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return default(T);
            }

            return list[0];
        }

        #endregion
    }
}
