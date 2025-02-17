using ScreenScene.Business.DTOs.Request;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Business.DTOs.Comment;

public class CommentResponse
{
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }
    
    public string UserId { get; set; } = null!;

    public ApplicationUser? User { get; set; }
    
    public int MovieId { get; set; }
    
    public MovieResponse? Movie { get; set; }
}