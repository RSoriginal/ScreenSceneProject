using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Data.Entities;

[Table("Tickets")]
public class Ticket : BaseEntity
{
    [Required]
    public int RowNumber { get; set; }
    
    [Required]
    public int SeatNumber { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public int UserId { get; set; }
}