using System;
using System.ComponentModel.DataAnnotations;
using DTO_Library.Models.Attributes;

namespace DTO_Library.Models
{
    public class User
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 30 characters.")]
        [FirstLetterCapital(ErrorMessage = "Username must start with a capital letter.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string UserPassword { get; set; }

        public User() { }

        public User(string userId, string userName, string userEmail, string userPassword)
        {
            UserId = userId;
            UserName = userName;
            UserEmail = userEmail;
            UserPassword = userPassword;
        }
    }
}