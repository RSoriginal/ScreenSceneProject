using ScreenScene.Data.Entities;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Business.DTOs.Ticket;

public class TicketResponse
{
    public int RowNumber { get; set; }
    
    public int SeatNumber { get; set; }
    
    public decimal Price { get; set; }
    
    public string UserId { get; set; } = null!;
    
    public ApplicationUser? User { get; set; } 
    
    public int SeanceId { get; set; }
    
    public Seance? Seance { get; set; }
}