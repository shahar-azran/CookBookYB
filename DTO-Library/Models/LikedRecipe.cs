using System;
using System.ComponentModel.DataAnnotations;

namespace DTO_Library.Models
{
    public class LikedRecipe
    {
        public int LikeId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        public LikedRecipe() { }

        public LikedRecipe(int likeId, string userId, int recipeId)
        {
            LikeId = likeId;
            UserId = userId;
            RecipeId = recipeId;
        }
    }
}