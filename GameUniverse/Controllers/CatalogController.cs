using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using GameUniverse.Data;
using GameUniverse.Models;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public IActionResult AddGame()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(Game game)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Index");
            }

            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditGame(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Index");
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> EditGame(Game game)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                _context.Update(game);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGame(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Index");
            }

            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
