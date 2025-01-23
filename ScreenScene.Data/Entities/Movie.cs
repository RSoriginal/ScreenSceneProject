using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Data.Entities;

[Table("Movies")]
public class Movie : BaseEntity
{
    [Required]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(1000)]
    public string Description { get; set; } = null!;
    
    [Required]
    [StringLength(1000)]
    public string TrailerUrl { get; set; } = null!;
    
    [Required]
    public DateTime Duration { get; set; }
    
    [Required]
    public DateTime ReleaseDate { get; set; }
    
    public IEnumerable<ActorMovie> ActorMovies { get; set; } = [];
    
    public IEnumerable<GenreMovie> GenreMovies { get; set; } = [];
    
    public IEnumerable<Seance> Seances { get; set; } = [];
    
    public IEnumerable<Proposition> Propositions { get; set; } = [];
    
    public IEnumerable<Grade> Grades { get; set; } = [];
    
    public IEnumerable<Comment> Comments { get; set; } = [];
}