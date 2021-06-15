using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Mustafa.Controllers
{
    public abstract class MustafaControllerBase: AbpController
    {
        protected MustafaControllerBase()
        {
            LocalizationSourceName = MustafaConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
