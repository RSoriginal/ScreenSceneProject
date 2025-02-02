using System.ComponentModel.DataAnnotations;

namespace ScreenScene.Business.DTOs;

public class SeanceUpdateRequest
{
    public int Id { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime AssignedAt { get; set; }
}