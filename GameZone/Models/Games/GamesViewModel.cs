using Demo.DAL._Data.Model;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models.Games
{
    public class GamesViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string ImageName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category? category { get; set; }
        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();

    }
}
