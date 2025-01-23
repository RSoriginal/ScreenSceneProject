using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Data.Entities;

[Table("Halls")]
public class Hall : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    public int RowCount { get; set; }
    
    [Required]
    public int SeatCount { get; set; }
    
    [Required]
    public int Capacity { get; set; }
    
    public IEnumerable<Seance> Seances { get; set; } = [];
}