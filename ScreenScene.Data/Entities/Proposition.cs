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
    public decimal Discount { get; set; }
    
    [Required]
    public int MovieId { get; set; }
    
    [Required]
    public int CinemaUserId { get; set; }
}