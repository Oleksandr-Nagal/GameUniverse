using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("IsAdmin") != "true")
        {
            return RedirectToAction("Login", "Account");
        }
        return View();
    }
}
