using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Business.DTOs.Proposition;

public class PropositionRequest
{
    [Required]
    [StringLength(1000)]
    public string Description {get; set;} = null!;

    [Required]
    [Column(TypeName="decimal(18,2)")]
    public decimal Discount { get; set; }
}