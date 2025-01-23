using Microsoft.EntityFrameworkCore;
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
    [Precision(18, 2)]
    public decimal Price { get; set; }
    
    [Required]
    public string UserId { get; set; }
    
    [Required]
    public int SeanceId { get; set; }
    public Seance Seance { get; set; }
}