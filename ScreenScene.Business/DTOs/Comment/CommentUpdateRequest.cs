using System.ComponentModel.DataAnnotations;

namespace ScreenScene.Business.DTOs.Comment;

public class CommentUpdateRequest
{
    public int Id { get; set; }
    
    [Required] 
    [StringLength(1000, MinimumLength = 5)]
    public string Content { get; set; } = null!;

    [Required]
    public DateTime CreatedDateTime { get; set; }
}