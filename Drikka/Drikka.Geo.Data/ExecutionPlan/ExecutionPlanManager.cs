using System;
using Drikka.Geo.Data.Contracts.ExecutionPlan;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.Query;
using Drikka.Geo.Data.Contracts.TypesMapping;

namespace Drikka.Geo.Data.ExecutionPlan
{
    /// <summary>
    /// Execution plan Manager
    /// </summary>
    public class ExecutionPlanManager : IExecutionPlanManager
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
        public ExecutionPlanManager(IMappingManager mappingManager, ITypeRegister typeRegister, IQueryTranslator queryTranslator)
        {
            this._mappingManager = mappingManager;
            this._typeRegister = typeRegister;
            this._queryTranslator = queryTranslator;
        }

        #endregion

        #region IExecutionplanManager Implementation
        
        /// <summary>
        /// Get insert plan for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>plan</returns>
        public virtual IOperationPlan GetInsertPlan(Type type)
        {
            var map = this._mappingManager.GetMapping(type);
            var insert = new InsertPlan(map, this._typeRegister);

            return insert;
        }

        /// <summary>
        /// Get update plan for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>plan</returns>
        public IOperationPlan GetUpdatePlan(Type type)
        {
            var map = this._mappingManager.GetMapping(type);
            var update = new UpdatePlan(map, this._typeRegister);

            return update;
        }

        /// <summary>
        /// Get select plan for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>plan</returns>
        public virtual IQueryPlan GetQueryPlan(Type type)
        {
            var map = this._mappingManager.GetMapping(type);
            var query = new QueryPlan(map, this._queryTranslator, this._typeRegister);

            return query;
        }

        /// <summary>
        /// Get delete plan for a given type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>plan</returns>
        public virtual IOperationPlan GetDeletePlan(Type type)
        {
            var map = this._mappingManager.GetMapping(type);
            var delete = new DeletePlan(map, this._typeRegister);

            return delete;
        }

        #endregion
    }
}
