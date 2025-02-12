namespace ScreenScene.Business.DTOs.Grade;

public class GradeResponse
{
    public int Id { get; set; }

    public int MovieId { get; set; }
    
    public int Mark { get; set; }
    
    public string UserId { get; set; } = null!;
}