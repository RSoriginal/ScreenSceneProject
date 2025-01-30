using System.ComponentModel.DataAnnotations;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Business.DTOs.Grade;

public class GradeRequest
{
    [Required]
    public int Mark { get; set; }
}