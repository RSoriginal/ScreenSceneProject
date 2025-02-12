using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Business.DTOs.Ticket;

public class TicketCreateRequest
{
    [Required]
    public int RowNumber { get; set; }
    
    [Required]
    public int SeatNumber { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 1000.00, ErrorMessage = "The price must be between 0.01 and 1,000.00.")]
    public decimal Price { get; set; }
    
    [Required]
    public IEnumerable<int> SeanceId { get; set; } = [];
}