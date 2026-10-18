using System;
using System.ComponentModel.DataAnnotations;

namespace DTO_Library.Models
{
    public class Rating
    {
        public int RatingID { get; set; }

        public int UserId { get; set; }

        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Score is required.")]
        [Range(1, 5, ErrorMessage = "Score must be between 1 and 5 stars.")]
        public int Score { get; set; }

        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string Comment { get; set; }

        public Rating() { }

        public Rating(int ratingID, int userId, int recipeId, int score, string comment)
        {
            RatingID = ratingID;
            UserId = userId;
            RecipeId = recipeId;
            Score = score;
            Comment = comment;
        }
    }
}