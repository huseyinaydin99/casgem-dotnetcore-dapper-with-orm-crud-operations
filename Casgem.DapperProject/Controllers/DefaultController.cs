using Microsoft.AspNetCore.Mvc;

namespace Casgem.DapperProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
