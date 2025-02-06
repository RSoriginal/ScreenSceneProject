namespace ScreenScene.Business.DTOs.Hall;

public class HallResponse
{
    public string Name { get; set; } = null!;
    
    public int RowCount { get; set; }
    
    public int ColumnCount { get; set; }
    
    public IEnumerable<SeanceResponse> Seances { get; set; } = [];
}