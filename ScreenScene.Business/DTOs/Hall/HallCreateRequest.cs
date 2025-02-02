using System.ComponentModel.DataAnnotations;
using ScreenScene.Data.Entities;

namespace ScreenScene.Business.DTOs;

public class HallCreateRequest
{
    [Required]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "The name must contain between 2 and 255 characters.")]
    public string Name { get; set; } = null!;
    
    [Required]
    public int RowCount { get; set; }
    
    [Required]
    public int SeatCount { get; set; }
    
    [Required]
    public int Capacity { get; set; }
}