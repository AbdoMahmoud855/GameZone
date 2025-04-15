using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models.Games
{
    public class GamesFormViewModel
    {
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;


        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem>? categories { get; set; }
        public List<int> SelectedDevices { get; set; } = default!;

        public IEnumerable<SelectListItem>? Devices { get; set; }
        [Required]
        [MaxLength(100000)]
        public string Description { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
       
    }
}
