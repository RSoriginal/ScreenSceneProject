using System.ComponentModel.DataAnnotations;

namespace ScreenScene.Business.DTOs;

public class SeanceRequest
{
    [Required]
    public DateTime AssignedAt { get; set; }
}