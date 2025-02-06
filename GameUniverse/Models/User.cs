using System.ComponentModel.DataAnnotations;

namespace GameUniverse.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public bool IsAdmin { get; set; }
    }
}
