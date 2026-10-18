using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DTO_Library.Models.Attributes
{
    public class IsrealIdCheck : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            string id = value.ToString();
            if (id.Length != 9 || !id.All(char.IsDigit))
            {
                return false;
            }
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = int.Parse(id[i].ToString());
                int factor = i % 2 == 0 ? 1 : 2;
                int product = digit * factor;
                sum += product > 9 ? product - 9 : product;
            }
            return sum % 10 == 0;
        }
    }
}