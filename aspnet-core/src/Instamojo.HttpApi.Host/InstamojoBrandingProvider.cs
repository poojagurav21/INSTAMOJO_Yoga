using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Instamojo;

[Dependency(ReplaceServices = true)]
public class InstamojoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Instamojo";
}
