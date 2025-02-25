using Microsoft.AspNetCore.Mvc;

namespace PerfumeSite.Controllers
{
    public class AdminController : Controller
    {




        public IActionResult AdminHomePage()
        {
            return View();
        }
    }
}
