using System;
using System.ComponentModel.DataAnnotations;

namespace DTO_Library.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }

        [Required(ErrorMessage = "Ingredient name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ingredient name must be between 2 and 50 characters.")]
        public string IngredientName { get; set; }

        public int UnitId { get; set; }

        public Ingredient() { }

        public Ingredient(int ingredientID, string ingredientName, int unitId)
        {
            IngredientID = ingredientID;
            IngredientName = ingredientName;
            UnitId = unitId;
        }
    }
}