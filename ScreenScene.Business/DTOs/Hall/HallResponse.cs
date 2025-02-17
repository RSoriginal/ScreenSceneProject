namespace ScreenScene.Business.DTOs.Hall;

public class HallResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    
    public int RowCount { get; set; }
    
    public int ColumnCount { get; set; }
}