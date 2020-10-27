using Abp.AspNetCore.Mvc.ViewComponents;

namespace Testing.Web.Views
{
    public abstract class TestingViewComponent : AbpViewComponent
    {
        protected TestingViewComponent()
        {
            LocalizationSourceName = TestingConsts.LocalizationSourceName;
        }
    }
}
