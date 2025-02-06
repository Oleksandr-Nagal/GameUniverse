using Microsoft.AspNetCore.Mvc;
using GameUniverse.Models;

namespace GameUniverse.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            var games = new List<Game>
            {
                new Game { Id = 1, Title = "Cyberpunk 2077", Description = "Futuristic RPG", Genre = "RPG", Developer = "CD Projekt Red", Publisher = "CD Projekt", ReleaseDate = new DateTime(2020, 12, 10), ImageUrl = "/images/cyberpunk.jpg" },
                new Game { Id = 2, Title = "The Witcher 3", Description = "Fantasy RPG", Genre = "RPG", Developer = "CD Projekt Red", Publisher = "CD Projekt", ReleaseDate = new DateTime(2015, 5, 19), ImageUrl = "/images/witcher3.jpg" },
                new Game { Id = 3, Title = "Elden Ring", Description = "Souls-like RPG", Genre = "Action RPG", Developer = "FromSoftware", Publisher = "Bandai Namco", ReleaseDate = new DateTime(2022, 2, 25), ImageUrl = "/images/eldenring.jpg" }
            };

            return View(games);
        }
    }
}
