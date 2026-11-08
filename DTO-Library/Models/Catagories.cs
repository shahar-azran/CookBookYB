using System;
using System.ComponentModel.DataAnnotations;

namespace DTO_Library.Models
{
    public class Catagories
    {
        public int CatId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Category name must be between 2 and 50 characters.")]
        public string CatagoryName { get; set; }

        public Catagories() { }

        public Catagories(int catId, string catagoryName)
        {
            CatId = catId;
            CatagoryName = catagoryName;
        }
    }
}