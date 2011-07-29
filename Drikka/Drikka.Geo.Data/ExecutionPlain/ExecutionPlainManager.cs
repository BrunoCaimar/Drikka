using System;
using Drikka.Geo.Data.Contracts.ExecutionPlain;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.Query;
using Drikka.Geo.Data.Contracts.TypesMapping;

namespace Drikka.Geo.Data.ExecutionPlain
{
    public class ExecutionPlainManager : IExecutionPlainManager
    {
        #region Fields

        /// <summary>
        /// Types register
        /// </summary>
        private readonly ITypeRegister _typeRegister;

        /// <summary>
        /// Mapping manager
        /// </summary>
        private readonly IMappingManager _mappingManager;

        /// <summary>
        /// Query translator
        /// </summary>
        private readonly IQueryTranslator _queryTranslator;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mappingManager">Mapping Manager</param>
        /// <param name="typeRegister">Types Register</param>
        /// <param name="queryTranslator">Query translator</param>
        public ExecutionPlainManager(IMappingManager mappingManager, ITypeRegister typeRegister, IQueryTranslator queryTranslator)
        {
            this._mappingManager = mappingManager;
            this._typeRegister = typeRegister;
            this._queryTranslator = queryTranslator;
        }

        #endregion

        #region IExecutionPlainManager Implementation
        
        /// <summary>
        /// Get insert plain for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Plain</returns>
        public virtual IOperationPlain GetInsertPlain(Type type)
        {
            var map = this._mappingManager.GetMapping(type);
            var insert = new InsertPlain(map, this._typeRegister);

            return insert;
        }

        /// <summary>
        /// Get select plain for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Plain</returns>
        public virtual IQueryPlain GetQueryPlain(Type type)
        {
            var map = this._mappingManager.GetMapping(type);
            var query = new QueryPlain(map, this._queryTranslator);

            return query;
        }

        #endregion
    }
}
