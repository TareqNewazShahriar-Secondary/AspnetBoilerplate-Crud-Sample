﻿using System.Threading.Tasks;
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

        public async Task<IViewComponentResult> InvokeAsync(string controller, string action, string printButtonText)
        {
            var model = new PrintingViewModel { Controller = controller, Action = action, PrintButtonText = printButtonText };
            return View(model);
        }
    }
}
