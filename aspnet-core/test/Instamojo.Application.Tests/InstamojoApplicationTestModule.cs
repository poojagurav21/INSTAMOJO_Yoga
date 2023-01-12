using Volo.Abp.Modularity;

namespace Instamojo;

[DependsOn(
    typeof(InstamojoApplicationModule),
    typeof(InstamojoDomainTestModule)
    )]
public class InstamojoApplicationTestModule : AbpModule
{

}
