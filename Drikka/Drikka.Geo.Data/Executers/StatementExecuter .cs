using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Drikka.Geo.Data.Contracts.Binders;
using Drikka.Geo.Data.Contracts.ExecutionPlain;
using Drikka.Geo.Data.Contracts.Provider;
using Drikka.Geo.Data.Contracts.Query;

namespace Drikka.Geo.Data.Executers
{
    public class StatementExecuter
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
        public StatementExecuter(IDataProvider dataProvider, IExecutionPlainManager plainManager, IBindManager bindManager)
        {
            this._dataProvider = dataProvider;
            this._plainManager = plainManager;
            this._bindManager = bindManager;
        }

        #endregion

        public void Insert(object domain)
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

        public IList Query(Type type)
        {
            var plain = this._plainManager.GetQueryPlain(type);

            return ExecuteQuery(plain.GetText(), type);
        }

        public IList Query<T>(IQuery<T> query)
        {
            var plain = this._plainManager.GetQueryPlain(query.QueriedType);

            return ExecuteQuery(plain.GetText(query), query.QueriedType);
        }

        private IList ExecuteQuery(string sqlText, Type type)
        {
            var binder = this._bindManager.GetBinder(type);
            var cmd = this._dataProvider.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sqlText;

            this._dataProvider.OpenConnection();
            cmd.Prepare();

            var list = new List<object>();

            using (var reader = cmd.ExecuteReader(CommandBehavior.Default))
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
    }
}
