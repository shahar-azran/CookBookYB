using System;
using System.ComponentModel.DataAnnotations;

namespace DTO_Library.Models
{
    public class UserAdmin
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Admin name is required.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Admin name must be between 2 and 30 characters.")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Admin password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Admin password must be at least 6 characters long.")]
        public string AdminPassword { get; set; }

        public UserAdmin() { }

        public UserAdmin(int userId, string adminName, string adminPassword)
        {
            UserId = userId;
            AdminName = adminName;
            AdminPassword = adminPassword;
        }
    }
}