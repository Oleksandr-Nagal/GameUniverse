using Microsoft.AspNetCore.Mvc;

namespace GameUniverse.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
