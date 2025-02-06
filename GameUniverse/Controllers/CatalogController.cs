using Microsoft.AspNetCore.Mvc;

namespace GameUniverse.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
