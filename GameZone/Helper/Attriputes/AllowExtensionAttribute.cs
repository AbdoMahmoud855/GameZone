using System.ComponentModel.DataAnnotations;

namespace GameZone.Helper.Attriputes
{
    public class AllowExtensionAttribute : ValidationAttribute
    {
        private readonly string _allowExtension;
        public AllowExtensionAttribute( string allowExtension)
        {
            _allowExtension = allowExtension;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null) { 
            var extension = Path.GetExtension(file.FileName);   
                var isAllowed=_allowExtension.Split(",").Contains(extension,StringComparer.OrdinalIgnoreCase);
                if (!isAllowed)
                    return new ValidationResult($"only {_allowExtension} are allowed plese enter this allawed");
        
           }
 return ValidationResult.Success;
        }


    }
}
