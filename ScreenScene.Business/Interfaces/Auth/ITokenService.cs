using ScreenScene.Business.DTOs.User;

namespace ScreenScene.Business.Interfaces;

public interface ITokenService
{
    public Task<TokenResponse> RefreshTokenAsync(TokenRequest tokenRequest);
    
    public Task<bool> RevokeTokenAsync(TokenRequest tokenRequest);
}