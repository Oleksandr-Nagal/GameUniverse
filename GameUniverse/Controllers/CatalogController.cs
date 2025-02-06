using Microsoft.AspNetCore.Mvc;
using GameUniverse.Data;
using GameUniverse.Models;
using System.Linq;

namespace GameUniverse.Controllers
{
    public class CatalogController : Controller
    {
        private readonly GameUniverseContext _context;

        public CatalogController(GameUniverseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var games = _context.Games.ToList();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
    }
}
