using System;
using System.Collections.Generic;
using DTO_Library.Models;

namespace DTO_Library.ViewModels
{
    public class RecipeDetailsViewModel
    {
        public Recipes Recipe { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Rating> Ratings { get; set; }
        public double AverageScore { get; set; }

        public RecipeDetailsViewModel()
        {
            Ingredients = new List<Ingredient>();
            Ratings = new List<Rating>();
        }
    }
}