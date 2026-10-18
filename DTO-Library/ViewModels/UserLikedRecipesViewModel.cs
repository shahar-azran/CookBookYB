using System;
using System.Collections.Generic;
using DTO_Library.Models;

namespace DTO_Library.ViewModels
{
    public class UserLikedRecipesViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<Recipes> LikedRecipes { get; set; }
        public UserLikedRecipesViewModel()
        {
            LikedRecipes = new List<Recipes>();
        }
    }
}