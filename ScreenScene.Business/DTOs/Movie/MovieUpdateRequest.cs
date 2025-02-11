using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Business.DTOs.Request;

public class MovieUpdateRequest
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(255, MinimumLength = 1, ErrorMessage = "The title must contain between 1 and 255 characters.")]
    public string Title { get; set; } = null!;
    
    [Required]
    [StringLength(10000, MinimumLength = 10, ErrorMessage = "The image URL must contain between 10 and 10000 characters.")]
    [Url(ErrorMessage = "The image URL must be a valid URL.")]
    public string ImageUrl { get; set; } = null!;
        
    [Required]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "The description must contain between 10 and 1000 characters.")]
    public string Description { get; set; } = null!;
        
    [Required]
    [StringLength(10000, MinimumLength = 10, ErrorMessage = "The trailer URL must contain between 10 and 10000 characters.")]
    [Url(ErrorMessage = "The trailer URL must be a valid URL.")]
    public string TrailerUrl { get; set; } = null!;
        
    [Required]
    [Range(typeof(TimeSpan), "00:01:00", "23:59:59", ErrorMessage = "The duration must be between 1 minute and 23 hours 59 minutes.")]
    public TimeSpan Duration { get; set; }
        
    [Required]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 10000.00, ErrorMessage = "The price must be between 0.01 and 10,000.00.")]
    public decimal Price { get; set; }

    [Required]
    public IEnumerable<int> GenreIds { get; set; } = [];

    [Required]
    public IEnumerable<int> ActorIds { get; set; } = [];
}