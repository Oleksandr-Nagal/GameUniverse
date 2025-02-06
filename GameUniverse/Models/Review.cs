using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameUniverse.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }

        public string Comment { get; set; }

        public DateTime ReviewDate { get; set; } = DateTime.Now;

        public User User { get; set; }
        public Game Game { get; set; }
    }
}
