using Microsoft.AspNetCore.Mvc;

namespace PerfumeSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
