namespace ScreenScene.Business.DTOs;

public class SeanceResponse
{
    public int Id { get; set; }

    public DateTime AssignedAt { get; set; }
    
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;
    
    public int HallId { get; set; }

    public string HallName { get; set; } = null!;
}