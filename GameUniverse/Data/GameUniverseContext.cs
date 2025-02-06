using Microsoft.EntityFrameworkCore;
using GameUniverse.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace GameUniverse.Data
{
    public class GameUniverseContext : DbContext
    {
        public GameUniverseContext(DbContextOptions<GameUniverseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
