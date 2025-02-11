using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Data.Entities;

[Table("Seances")]
public class Seance : BaseEntity
{
    [Required]
    public DateTime AssignedAt { get; set; }

    [Required]
    public int MovieId { get; set; }
    public Movie? Movie { get; set; }
    
    [Required]
    public int HallId { get; set; }
    public Hall? Hall { get; set; }

    public ICollection<Ticket> Tickets { get; set; } = [];
}