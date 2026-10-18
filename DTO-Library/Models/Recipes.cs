using System;
using System.ComponentModel.DataAnnotations;
using DTO_Library.Models.Attributes;

namespace DTO_Library.Models
{
    public class Recipes
    {
        public int RecipeId { get; set; }

        public int UserId { get; set; }

        public int CatId { get; set; }

        [Required(ErrorMessage = "Recipe name is required.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Recipe name must be between 2 and 80 characters.")]
        [FirstLetterCapital(ErrorMessage = "Recipe name must start with a capital letter.")]
        public string RecipesName { get; set; }

        [Required(ErrorMessage = "Preparation instructions are required.")]
        [StringLength(4000, MinimumLength = 10, ErrorMessage = "Preparation instructions must be at least 10 characters.")]
        public string PreperationMethod { get; set; }

        [Required(ErrorMessage = "Dish photo is required.")]
        [ImgCheck(ErrorMessage = "Image must be a valid file ending with .jpg, .png, or .gif")]
        public string DishPhoto { get; set; }

        public Recipes() { }

        public Recipes(int recipeId, int userId, int catId, string recipesName, string preperationMethod, string dishPhoto)
        {
            RecipeId = recipeId;
            UserId = userId;
            CatId = catId;
            RecipesName = recipesName;
            PreperationMethod = preperationMethod;
            DishPhoto = dishPhoto;
        }
    }
}