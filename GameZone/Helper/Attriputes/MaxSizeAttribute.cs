﻿using System.ComponentModel.DataAnnotations;

namespace GameZone.Helper.Attriputes
{
    public class MaxSizeAttribute : ValidationAttribute
    {
private readonly int _maxSize;
        public MaxSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {

                if (file.Length > _maxSize)
                {
                    return new ValidationResult($"Maximum allowed size is {_maxSize}");

                }

            }
            return ValidationResult.Success;
        }

    }
}
