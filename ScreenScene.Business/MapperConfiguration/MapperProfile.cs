using AutoMapper;
using ScreenScene.Business.DTOs.Actor;
using ScreenScene.Data.Entities;

namespace ScreenScene.Business.MapperConfiguration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // CreateMap<Actor, ActorCreateRequest>()
            //     .ForMember(dest => dest.ColorName, 
            //         opt => opt.MapFrom(src => src.Color.Name));
            // CreateMap<ActorResponse, Actor>();
        }
    }
}
