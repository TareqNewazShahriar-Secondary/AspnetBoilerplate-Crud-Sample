using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Testing.Controllers;

namespace Testing.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TestingControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
