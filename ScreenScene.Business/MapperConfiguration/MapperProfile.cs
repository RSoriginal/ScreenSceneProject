using AutoMapper;
using ScreenScene.Business.DTOs;
using ScreenScene.Business.DTOs.Actor;
using ScreenScene.Business.DTOs.Comment;
using ScreenScene.Business.DTOs.Grade;
using ScreenScene.Business.DTOs.Hall;
using ScreenScene.Business.DTOs.Proposition;
using ScreenScene.Business.DTOs.Request;
using ScreenScene.Business.DTOs.Ticket;
using ScreenScene.Data.Entities;

namespace ScreenScene.Business.MapperConfiguration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ActorCreateRequest, Actor>();
            CreateMap<ActorUpdateRequest, Actor>();
            CreateMap<Actor, ActorResponse>();

            CreateMap<GenreCreateRequest, Genre>();
            CreateMap<GenreUpdateRequest, Genre>();
            CreateMap<Genre, GenreResponse>();

            CreateMap<HallCreateRequest, Hall>();
            CreateMap<HallUpdateRequest, Hall>();
            CreateMap<Hall, HallResponse>();
            //.ForMember(dest => dest.Seances, opt => opt.MapFrom(src => src.Seances.Select(s => s.Hall)));

            CreateMap<CommentCreateRequest, Comment>();
            CreateMap<CommentUpdateRequest, Comment>();
            CreateMap<Comment, CommentResponse>();

            CreateMap<GradeCreateRequest, Grade>();
            CreateMap<GradeUpdateRequest, Grade>();
            CreateMap<Grade, GradeResponse>();

            CreateMap<MovieCreateRequest, Movie>();
            CreateMap<MovieUpdateRequest, Movie>();
            CreateMap<Movie, MovieResponse>();

            CreateMap<PropositionCreateRequest, Proposition>();
            CreateMap<PropositionUpdateRequest, Proposition>();
            CreateMap<Proposition, PropositionResponse>();

            CreateMap<SeanceCreateRequest, Seance>();
            CreateMap<SeanceUpdateRequest, Seance>();
            CreateMap<Seance, SeanceResponse>();

            CreateMap<TicketCreateRequest, Ticket>();
            CreateMap<TicketUpdateRequest, Ticket>();
            CreateMap<Ticket, TicketResponse>();
        }
    }
}
