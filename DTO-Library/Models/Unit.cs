using System;
using System.ComponentModel.DataAnnotations;

namespace DTO_Library.Models
{
    public class Unit
    {
        public int UnitId { get; set; }

        [Required(ErrorMessage = "Unit name is required.")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Unit name cannot exceed 30 characters.")]
        public string UnitName { get; set; }

        [StringLength(10, ErrorMessage = "Unit symbol cannot exceed 10 characters.")]
        public string UnitSymbol { get; set; }

        public Unit() { }

        public Unit(int unitId, string unitName, string unitSymbol)
        {
            UnitId = unitId;
            UnitName = unitName;
            UnitSymbol = unitSymbol;
        }
    }
}