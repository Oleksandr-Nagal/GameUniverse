using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameUniverse.Models
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Points { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
    }
}
