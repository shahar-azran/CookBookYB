using System;
using System.ComponentModel.DataAnnotations;

namespace DTO_Library.Models.Attributes
{
    public class FirstLetterCapitalAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }
            string str = value as string;
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                {
                    return false;
                }
            }
            if (str[0] < 'A' || str[0] > 'Z')
            {
                return false;
            }
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] < 'a' || str[i] > 'z')
                {
                    return false;
                }
            }
            return true;
        }
    }
}