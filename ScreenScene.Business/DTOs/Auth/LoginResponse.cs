namespace ScreenScene.Business.DTOs.User;

public class LoginResponse
{
    public string UserId { get; set; }

    public string UserName { get; set; }

    public TokenResponse Token { get; set; }
}