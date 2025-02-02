using System.ComponentModel.DataAnnotations;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Business.DTOs.Comment;

public class CommentCreateRequest
{
    [Required] 
    [StringLength(1000, MinimumLength = 5)]
    public string Content { get; set; } = null!;

    [Required]
    public DateTime CreatedDateTime { get; set; }
}