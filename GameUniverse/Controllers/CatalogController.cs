using GameUniverse.Data;
using GameUniverse.Models;
using Microsoft.AspNetCore.Mvc;

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

        var userId = HttpContext.Session.GetString("UserId");
        if (userId != null)
        {
            var isInWishlist = _context.Wishlist.Any(w => w.UserId == int.Parse(userId) && w.GameId == id);
            ViewBag.IsInWishlist = isInWishlist;
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

        if (ModelState.IsValid)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        return View(game);
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

    [HttpPost]
    public async Task<IActionResult> AddComment(int gameId, string content)
    {
        var userId = HttpContext.Session.GetString("UserId");
        if (userId == null) return RedirectToAction("Login", "Account");

        var comment = new Comments
        {
            GameId = gameId,
            UserId = int.Parse(userId),
            Content = content,
            CommentDate = DateTime.Now
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return RedirectToAction("Details", new { id = gameId });

    }
}