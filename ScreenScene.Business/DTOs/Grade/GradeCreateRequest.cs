using System.ComponentModel.DataAnnotations;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Business.DTOs.Grade;

public class GradeCreateRequest
{
    [Required]
    [Range(0, 10, ErrorMessage = "The value must be between 0 and 10.")]
    public int Mark { get; set; }
}