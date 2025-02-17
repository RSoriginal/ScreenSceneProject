using System.ComponentModel.DataAnnotations;

namespace ScreenScene.Business.DTOs;

public class GenreCreateRequest
{
    [Required]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "The name must contain between 2 and 255 characters.")]
    public string Name { get; set; } = null!;
}