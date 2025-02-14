using ScreenScene.Business.DTOs.User;
using ScreenScene.Data.Entities.Auth;
using System.Security.Claims;

namespace ScreenScene.Business.Interfaces;

public interface IAuthenticationService
{
    public Task<LoginResponse> LoginAsync(LoginRequest login);

    public Task RegistrationAsync(RegistrationRequest registration);

    public Task<ApplicationUser?> GetUserAsync(ClaimsPrincipal userPrincipal);
}