using System.ComponentModel.DataAnnotations;

namespace ScreenScene.Business.DTOs;

public class SeanceCreateRequest
{
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime AssignedAt { get; set; }
}