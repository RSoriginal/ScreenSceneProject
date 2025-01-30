using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ScreenScene.Data.Entities;

[Table("Movies")]
public class Movie : BaseEntity
{
    [Required]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(10000)]
    [Url]
    public string ImageUrl { get; set; } = null!;
    
    [Required]
    [StringLength(1000)]
    public string Description { get; set; } = null!;
    
    [Required]
    [StringLength(1000)]
    [Url]
    public string TrailerUrl { get; set; } = null!;
    
    [Required]
    public TimeSpan Duration { get; set; }
    
    [Required]
    public DateTime ReleaseDate { get; set; }
    
    [Column(TypeName="decimal(18,2)")]
    public decimal Price { get; set; }
    
    public IEnumerable<ActorMovie> ActorMovies { get; set; } = [];
    
    public IEnumerable<GenreMovie> GenreMovies { get; set; } = [];
    
    public IEnumerable<Seance> Seances { get; set; } = [];
    
    public IEnumerable<Proposition> Propositions { get; set; } = [];
    
    public IEnumerable<Grade> Grades { get; set; } = [];
    
    public IEnumerable<Comment> Comments { get; set; } = [];
}