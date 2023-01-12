using Instamojo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Instamojo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class InstamojoController : AbpControllerBase
{
    protected InstamojoController()
    {
        LocalizationResource = typeof(InstamojoResource);
    }
}
