using System;
using System.Collections.Generic;
using DTO_Library.Models;

namespace DTO_Library.ViewModels
{
    public class CreateRecipeViewModel
    {
        public Recipes Recipe { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Catagories> AvailableCategories { get; set; }
        public List<Unit> AvailableUnits { get; set; }

        public CreateRecipeViewModel()
        {
            Recipe = new Recipes();
            Ingredients = new List<Ingredient>();
            AvailableCategories = new List<Catagories>();
            AvailableUnits = new List<Unit>();
        }
    }
}