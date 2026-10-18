using System;
using System.ComponentModel.DataAnnotations;

namespace DTO_Library.Models
{
    public class RecipeIngredient
    {
        public int ItemID { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.1, 1000, ErrorMessage = "Amount must be a positive value.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Unit is required.")]
        [StringLength(30, ErrorMessage = "Unit cannot exceed 30 characters.")]
        public string Unit { get; set; }

        public RecipeIngredient() { }

        public RecipeIngredient(int itemID, int recipeId, int ingredientId, double amount, string unit)
        {
            ItemID = itemID;
            RecipeId = recipeId;
            IngredientId = ingredientId;
            Amount = amount;
            Unit = unit;
        }
    }
}