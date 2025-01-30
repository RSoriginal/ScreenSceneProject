using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Business.DTOs.Ticket;

public class TicketRequest
{
    [Required]
    public int RowNumber { get; set; }
    
    [Required]
    public int SeatNumber { get; set; }
    
    [Required]
    [Column(TypeName="decimal(18,2)")]
    public decimal Price { get; set; }
}