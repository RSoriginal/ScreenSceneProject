using ScreenScene.Business.DTOs.Ticket;
using ScreenScene.Data.Entities;

namespace ScreenScene.Business.DTOs;

public class SeanceResponse
{
    public DateTime AssignedAt { get; set; }
    
    public int MovieId { get; set; }
    
    public Movie? Movie { get; set; }
    
    public int HallId { get; set; }
    
    public Hall? Hall { get; set; }

    public IEnumerable<TicketResponse> Tickets { get; set; } = [];
}