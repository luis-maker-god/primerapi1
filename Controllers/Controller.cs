using Microsoft.AspNetCore.Mvc;

namespace primerapi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
