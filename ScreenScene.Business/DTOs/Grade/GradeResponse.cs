using ScreenScene.Business.DTOs.Request;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Business.DTOs.Grade;

public class GradeResponse
{
    public int MovieId { get; set; }
    
    public MovieResponse? Movie { get; set; }
    
    public int Mark { get; set; }
    
    public string UserId { get; set; } = null!;

    public ApplicationUser? User { get; set; }
}