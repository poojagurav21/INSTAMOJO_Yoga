using Instamojo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Instamojo.Permissions;

public class InstamojoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(InstamojoPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(InstamojoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<InstamojoResource>(name);
    }
}
