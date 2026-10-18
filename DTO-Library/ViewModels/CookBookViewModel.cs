using System;
using System.Collections.Generic;
using DTO_Library.Models;

namespace DTO_Library.ViewModels
{
    public class CookBookViewModel
    {
        public List<RecipeCatagories> RecipeCatagories { get; set; }
        public List<Recipes> Recipes { get; set; }

        public CookBookViewModel()
        {
            RecipeCatagories = new List<RecipeCatagories>();
            Recipes = new List<Recipes>();
        }
        public void AddRecipeCatagory(RecipeCatagories recipeCatagory)
        {
            if (recipeCatagory != null)
            {
                RecipeCatagories.Add(recipeCatagory);
            }
        }
        public void AddRecipes(Recipes recipe)
        {
            if (recipe != null)
            {
                Recipes.Add(recipe);
            }
        }
        public RecipeCatagories GetRecipeCatagory(int index)
        {
            if (index >= 0 && index < RecipeCatagories.Count)
            {
                return RecipeCatagories[index];
            }
            return null;
        }
        public Recipes GetRecipes(int index)
        {
            if (index >= 0 && index < Recipes.Count)
            {
                return Recipes[index];
            }
            return null;
        }
        public int GetRecipeCatagoriesCount()
        {
            return RecipeCatagories.Count;
        }
        public int GetRecipeCount()
        {
            return Recipes.Count;
        }
    }
}