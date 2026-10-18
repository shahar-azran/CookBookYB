using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DTO_Library.Models;

namespace DTO_Library.ViewModels
{
    public class AddIngredientViewModel
    {
        [Required(ErrorMessage = "Ingredient name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ingredient name must be between 2 and 50 characters.")]
        public string IngredientName { get; set; }
        [Required(ErrorMessage = "Please select a unit.")]
        public int SelectedUnitId { get; set; }
        public List<Unit> AvailableUnits { get; set; }
        public AddIngredientViewModel()
        {
            AvailableUnits = new List<Unit>();
        }
    }
}