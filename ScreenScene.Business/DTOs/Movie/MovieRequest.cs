using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Business.DTOs.Request;

public class MovieRequest
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
    [StringLength(10000)]
    [Url]
    public string TrailerUrl { get; set; } = null!;
        
    [Required]
    public TimeSpan Duration { get; set; }
        
    [Required]
    public DateTime ReleaseDate { get; set; }
    
    [Column(TypeName="decimal(18,2)")]
    public decimal Price { get; set; }
}