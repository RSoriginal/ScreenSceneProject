using System.ComponentModel.DataAnnotations;
using ScreenScene.Data.Entities;

namespace ScreenScene.Business.DTOs;

public class HallRequest
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
}