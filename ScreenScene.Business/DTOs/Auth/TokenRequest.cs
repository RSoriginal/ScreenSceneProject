using System.ComponentModel.DataAnnotations;

namespace ScreenScene.Business.DTOs.User;

public class TokenRequest
{
    [Required(ErrorMessage = "Access Token is required")]
    public string AccessToken { get; set; }

    [Required(ErrorMessage = "Refresh Token is required")]
    public string RefreshToken { get; set; }
}