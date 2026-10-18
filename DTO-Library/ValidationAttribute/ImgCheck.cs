using System;
using System.ComponentModel.DataAnnotations;

namespace DTO_Library.Models.Attributes
{
    public class ImgCheck : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }
            string[] allowedExtensions = { ".jpg", ".png", ".gif" };
            string fileName = value.ToString();

            if (fileName.Length < 4)
            {
                return false;
            }

            string extension = fileName.Substring(fileName.Length - 4).ToLower();
            foreach (string fileExtension in allowedExtensions)
            {
                if (fileExtension == extension)
                {
                    return true;
                }
            }
            return false;
        }
    }
}