using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Data.Entities;

[Table("Propositions")]
public class Proposition : BaseEntity
{
    [Required]
    [StringLength(1000)]
    public string Description {get; set;} = null!;

    [Required]
    [Precision(18, 2)]
    public decimal Discount { get; set; }
    
    [Required]
    public int MovieId { get; set; }
    
    public Movie? Movie { get; set; }
    
    [Required]
    public string UserId { get; set; } = null!;
}