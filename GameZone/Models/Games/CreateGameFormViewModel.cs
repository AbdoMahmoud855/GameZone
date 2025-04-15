using Demo.DAL._Data.Model;
using GameZone.Helper.Attriputes;
using GameZone.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GameZone.Models.Games
{
    public class CreateGameFormViewModel: GamesFormViewModel
    {

        [AllowExtension(FileSetting.AllowedExtentions), MaxSize(FileSetting.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;

    }
}
