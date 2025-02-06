using ScreenScene.Business.DTOs.Hall;
using ScreenScene.Business.DTOs.Request;
using ScreenScene.Business.DTOs.Ticket;

namespace ScreenScene.Business.DTOs;

public class SeanceResponse
{
    public DateTime AssignedAt { get; set; }
    
    public int MovieId { get; set; }
    
    public MovieResponse? Movie { get; set; }
    
    public int HallId { get; set; }
    
    public HallResponse? Hall { get; set; }

    public IEnumerable<TicketResponse> Tickets { get; set; } = [];
}