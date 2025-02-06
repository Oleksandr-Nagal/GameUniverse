using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using GameUniverse.Data;
using GameUniverse.Models;
using System.Linq;

public class AdminController : Controller
{
    private readonly GameUniverseContext _context;

    public AdminController(GameUniverseContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("IsAdmin") != "true")
        {
            return RedirectToAction("Login", "Account");
        }
        return View();
    }

    public IActionResult Users()
    {
        if (HttpContext.Session.GetString("IsAdmin") != "true")
        {
            return RedirectToAction("Login", "Account");
        }

        var users = _context.Users.ToList();
        return View(users);
    }
}
