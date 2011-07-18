using System.Data;
using System.Data.SqlServerCe;
using Drikka.Geo.Data.Binders;
using Drikka.Geo.Data.Contracts.Binders;
using Drikka.Geo.Data.Contracts.ExecutionPlain;
using Drikka.Geo.Data.Contracts.Mapping;
using Drikka.Geo.Data.Contracts.Provider;
using Drikka.Geo.Data.Contracts.TypesMapping;
using Drikka.Geo.Data.ExecutionPlain;
using Drikka.Geo.Data.Mapping;
using Drikka.Geo.Data.Providers;
using Drikka.Geo.Data.TypesMapping;
using Ninject.Modules;

namespace Drikka.Geo.Tests.Common.IoC
{
    class TestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataProvider>().To<DataProvider>();
            Bind<IExecutionPlainManager>().To<ExecutionPlainManager>().InSingletonScope();
            Bind<ITypeRegister>().To<TypeRegister>().InSingletonScope();
            Bind<IMappingManager>().To<MappingManager>().InSingletonScope();
            Bind<IDbConnection>().To<SqlCeConnection>().WithConstructorArgument("connectionString", "DataSource=TestsDatabase.sdf");
            Bind<IBindManager>().To<BindManager>().InSingletonScope();
        }
    }
}
