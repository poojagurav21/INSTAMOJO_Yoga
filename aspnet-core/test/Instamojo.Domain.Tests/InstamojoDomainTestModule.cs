using Instamojo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Instamojo;

[DependsOn(
    typeof(InstamojoEntityFrameworkCoreTestModule)
    )]
public class InstamojoDomainTestModule : AbpModule
{

}
