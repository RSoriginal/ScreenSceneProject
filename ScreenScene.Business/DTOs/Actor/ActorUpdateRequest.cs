using System.ComponentModel.DataAnnotations;
using ScreenScene.Data.Entities;

namespace ScreenScene.Business.DTOs.Actor;

public class ActorUpdateRequest
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [StringLength(255)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string LastName { get; set; } = null!;
    
}