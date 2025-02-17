using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Data.Entities;

[Table("Comments")]
public class Comment : BaseEntity
{
    [Required] 
    [StringLength(1000)]
    public string Content { get; set; } = null!;

    [Required]
    public DateTime CreatedDateTime { get; set; }
    
    [Required]
    public string UserId { get; set; } = null!;

    public ApplicationUser? User { get; set; }
    
    [Required]
    public int MovieId { get; set; }
    
    public Movie? Movie { get; set; }
}