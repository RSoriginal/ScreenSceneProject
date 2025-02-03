using System.ComponentModel.DataAnnotations;

namespace ScreenScene.Business.DTOs.Actor;

public class ActorCreateRequest
{
    [Required]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "The name must contain between 2 and 255 characters.")]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "The last name must contain between 2 and 255 characters.")]
    public string LastName { get; set; } = null!;
}