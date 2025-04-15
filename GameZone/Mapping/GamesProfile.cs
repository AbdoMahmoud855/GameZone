using AutoMapper;
using Demo.DAL._Data.Model;
using GameZone.Models.Games;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameZone.Mapping
{
    public class GamesProfile : Profile
    {
        public GamesProfile() {

            CreateMap<CreateGameFormViewModel, Game>()
             .ForMember(dest => dest.Devices,
              opt => opt.MapFrom(src => src.SelectedDevices.Select(id => new GameDevice { DeviceId = id })))
            .ReverseMap()
      ;
            CreateMap<Game, EditeGamesViewModel>()
              .ForMember(dest => dest.SelectedDevices,
                         opt => opt.MapFrom(src => src.Devices.Select(d => d.DeviceId).ToList()))
              .ForMember(dest => dest.Devices, opt => opt.Ignore())
              .ForMember(dest => dest.categories, opt => opt.Ignore())
              
              ;
                      CreateMap<EditeGamesViewModel, Game>()
             .ForMember(dest => dest.Devices,
              opt => opt.MapFrom(src => src.SelectedDevices.Select(id => new GameDevice { DeviceId = id })))
           
      ;
            CreateMap<Game, GamesViewModel>();
        }
    }
}
