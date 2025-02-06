using System.ComponentModel.DataAnnotations;

namespace GameUniverse.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }
    }
}
