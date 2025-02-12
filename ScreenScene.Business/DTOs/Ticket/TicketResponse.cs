namespace ScreenScene.Business.DTOs.Ticket;

public class TicketResponse
{
    public int Id { get; set; }

    public int RowNumber { get; set; }
    
    public int ColumnNumber { get; set; }
    
    public decimal Price { get; set; }
    
    public string UserId { get; set; } = null!;
    
    public int SeanceId { get; set; }
}