using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Business.DTOs.Proposition;

public class PropositionUpdateRequest
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "The description must contain between 10 and 1000 characters.")]
    public string Description { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 100.00, ErrorMessage = "The discount must be between 0.01 and 100.00.")]
    public decimal Discount { get; set; }
}