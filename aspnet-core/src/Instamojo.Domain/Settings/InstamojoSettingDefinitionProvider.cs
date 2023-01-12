using Volo.Abp.Settings;

namespace Instamojo.Settings;

public class InstamojoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(InstamojoSettings.MySetting1));
    }
}
