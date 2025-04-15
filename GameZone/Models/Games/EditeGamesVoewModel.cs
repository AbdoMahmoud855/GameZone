using GameZone.Helper.Attriputes;
using GameZone.Helper;

namespace GameZone.Models.Games
{
    public class EditeGamesViewModel: GamesFormViewModel
    {
        public int Id { get; set; }
        [AllowExtension(FileSetting.AllowedExtentions), MaxSize(FileSetting.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
