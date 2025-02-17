using System.ComponentModel.DataAnnotations;

namespace ScreenScene.Business.DTOs.Comment;

public class CommentCreateRequest
{
    [Required] 
    [StringLength(1000, MinimumLength = 5)]
    public string Content { get; set; } = null!;

    [Required]
    public DateTime CreatedDateTime { get; set; }
    
    [Required]
    public string UserId { get; set; }
    
    [Required]
    public int MovieId { get; set; }
}