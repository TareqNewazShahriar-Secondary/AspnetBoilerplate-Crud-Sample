using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Testing.Web.Views
{
    public abstract class TestingRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected TestingRazorPage()
        {
            LocalizationSourceName = TestingConsts.LocalizationSourceName;
        }
    }
}
