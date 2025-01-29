using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Data.Entities;

[Table("Grades")]
public class Grade : BaseEntity
{
    [Required]
    public int MovieId { get; set; }
    
    public Movie? Movie { get; set; }
    
    [Required]
    public int Mark { get; set; }
    
    [Required]
    public string UserId { get; set; } = null!;

    public ApplicationUser? User { get; set; }
}