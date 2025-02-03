using ScreenScene.Business.DTOs.Request;

namespace ScreenScene.Business.DTOs.Hall;

public class HallResponse
{
    public string Name { get; set; } = null!;
    
    public int RowCount { get; set; }
    
    public int SeatCount { get; set; }
    
    public int Capacity { get; set; }
    
    public IEnumerable<SeanceResponse> Seances { get; set; } = [];
}