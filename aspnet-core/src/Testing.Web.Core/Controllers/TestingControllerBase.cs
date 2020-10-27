using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Testing.Controllers
{
    public abstract class TestingControllerBase: AbpController
    {
        protected TestingControllerBase()
        {
            LocalizationSourceName = TestingConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
