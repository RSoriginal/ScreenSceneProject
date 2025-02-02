using System.ComponentModel.DataAnnotations;

namespace ScreenScene.Business.DTOs.Grade;

public class GradeUpdateRequest
{
    public int Id { get; set; }
    
    [Required]
    [Range(0, 10, ErrorMessage = "The value must be between 0 and 10.")]
    public int Mark { get; set; }
}