﻿using System.ComponentModel.DataAnnotations;

namespace GameUniverse.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public bool IsAdmin { get; set; } = false;
    }
}
