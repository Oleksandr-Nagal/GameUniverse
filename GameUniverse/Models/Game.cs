using System.ComponentModel.DataAnnotations;

namespace GameUniverse.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }
    }
}
