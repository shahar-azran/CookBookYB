using System;
using System.Collections.Generic;
using DTO_Library.Models;

namespace DTO_Library.ViewModels
{
    public class CreateRecipeViewModel
    {
        public Recipes Recipe { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public List<RecipeCatagories> AvailableCategories { get; set; }
        public List<Unit> AvailableUnits { get; set; }

        public CreateRecipeViewModel()
        {
            Recipe = new Recipes();
            Ingredients = new List<RecipeIngredient>();
            AvailableCategories = new List<RecipeCatagories>();
            AvailableUnits = new List<Unit>();
        }
    }
}