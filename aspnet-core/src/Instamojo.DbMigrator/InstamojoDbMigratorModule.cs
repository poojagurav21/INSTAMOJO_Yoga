using Instamojo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Instamojo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(InstamojoEntityFrameworkCoreModule),
    typeof(InstamojoApplicationContractsModule)
    )]
public class InstamojoDbMigratorModule : AbpModule
{

}
