namespace ScreenScene.Business.DTOs;

public class HallResponse
{
    public string Name { get; set; } = null!;
    
    public int RowCount { get; set; }
    
    public int SeatCount { get; set; }
    
    public int Capacity { get; set; }
}