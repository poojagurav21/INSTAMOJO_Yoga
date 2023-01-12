using System;
using System.Collections.Generic;
using System.Text;
using Instamojo.Localization;
using Volo.Abp.Application.Services;

namespace Instamojo;

/* Inherit your application services from this class.
 */
public abstract class InstamojoAppService : ApplicationService
{
    protected InstamojoAppService()
    {
        LocalizationResource = typeof(InstamojoResource);
    }
}
