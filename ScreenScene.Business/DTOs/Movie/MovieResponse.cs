using ScreenScene.Business.DTOs.Actor;
using ScreenScene.Business.DTOs.Comment;
using ScreenScene.Business.DTOs.Grade;
using ScreenScene.Business.DTOs.Proposition;

namespace ScreenScene.Business.DTOs.Request;

public class MovieResponse
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    
    public string ImageUrl { get; set; } = null!;
        
    public string Description { get; set; } = null!;
        
    public string TrailerUrl { get; set; } = null!;
        
    public TimeSpan Duration { get; set; }
        
    public DateTime ReleaseDate { get; set; }
    
    public decimal Price { get; set; }
    
    public IEnumerable<ActorResponse> Actors { get; set; } = [];
    
    public IEnumerable<GenreResponse> Genres { get; set; } = [];
    
    public IEnumerable<SeanceResponse> Seances { get; set; } = [];
    
    public IEnumerable<PropositionResponse> Propositions { get; set; } = [];
    
    public IEnumerable<GradeResponse> Grades { get; set; } = [];
    
    public IEnumerable<CommentResponse> Comments { get; set; } = [];
}