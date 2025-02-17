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

            CreateMap<CommentCreateRequest, Comment>();
            CreateMap<CommentUpdateRequest, Comment>();
            CreateMap<Comment, CommentResponse>();

            CreateMap<GradeCreateRequest, Grade>();
            CreateMap<GradeUpdateRequest, Grade>();
            CreateMap<Grade, GradeResponse>();

            CreateMap<MovieCreateRequest, Movie>()
                .ForMember(dest => dest.GenreMovies, opt => opt.MapFrom(src => src.GenreIds.Select(id => new GenreMovie { GenreId = id })))
                .ForMember(dest => dest.ActorMovies, opt => opt.MapFrom(src => src.ActorIds.Select(id => new ActorMovie { ActorId = id })));
            CreateMap<MovieUpdateRequest, Movie>()
                .ForMember(dest => dest.GenreMovies, opt => opt.MapFrom(src => src.GenreIds.Select(id => new GenreMovie { GenreId = id })))
                .ForMember(dest => dest.ActorMovies, opt => opt.MapFrom(src => src.ActorIds.Select(id => new ActorMovie { ActorId = id })));
            CreateMap<Movie, MovieResponse>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.GenreMovies.Select(genre => new GenreResponse
                {
                    Id = genre.GenreId,
                    Name = genre.Genre!.Name
                })))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.ActorMovies.Select(actor => new ActorResponse
                {
                    Id = actor.ActorId,
                    FirstName = actor.Actor!.FirstName,
                    LastName = actor.Actor.LastName
                })));

            CreateMap<PropositionCreateRequest, Proposition>();
            CreateMap<PropositionUpdateRequest, Proposition>();
            CreateMap<Proposition, PropositionResponse>();

            CreateMap<SeanceCreateRequest, Seance>();
            CreateMap<SeanceUpdateRequest, Seance>();
            CreateMap<Seance, SeanceResponse>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Movie!.Title))
                .ForMember(dest => dest.HallName, opt => opt.MapFrom(src => src.Hall!.Name));

            CreateMap<TicketCreateRequest, Ticket>()
                .ForMember(dest => dest.SeanceId, opt => opt.MapFrom(src => src.SeanceId));
            CreateMap<TicketUpdateRequest, Ticket>()
                .ForMember(dest => dest.SeanceId, opt => opt.MapFrom(src => src.SeanceId));
            CreateMap<Ticket, TicketResponse>();
        }
    }
}
