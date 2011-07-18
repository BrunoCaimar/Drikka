using System;
using Drikka.Geo.Data.Contracts.Binders;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.TypesMapping;

namespace Drikka.Geo.Data.Binders
{
    public class BindManager : IBindManager
    {
        private readonly IMappingManager _mappingManager;

        private readonly ITypeRegister _typeRegister;

        public BindManager(IMappingManager mappingManager, ITypeRegister typeRegister)
        {
            this._mappingManager = mappingManager;
            this._typeRegister = typeRegister;
        }

        /// <summary>
        /// Get the binder for a type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Binder</returns>
        public IBinder GetBinder(Type type)
        {
            var map = this._mappingManager.GetMapping(type);
            var binder = new ObjectBinder(map, this._typeRegister);

            return binder;
        }
    }
}
