using System.Threading.Tasks;
using Abp.Configuration.Startup;
using Testing.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Web.Views.Shared.Components.Printing
{
    public class PrintingViewComponent : TestingViewComponent
    {   
        public PrintingViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(string partialPath)
        {
            var model = new PrintingViewModel
            {
                PartialPath = partialPath
            };

            return View(model);
        }
    }
}
