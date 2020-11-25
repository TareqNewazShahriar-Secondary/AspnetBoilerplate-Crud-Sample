using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Web.Views.Shared.Components.Printing
{
    public class PrintingViewModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ExcelAction { get; set; }
        public dynamic ActionParam { get; set; }
        public string PrintButtonText { get; set; }
    }
}
