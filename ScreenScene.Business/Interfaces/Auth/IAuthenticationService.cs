using ScreenScene.Business.DTOs.User;

namespace ScreenScene.Business.Interfaces;

public interface IAuthenticationService
{
    public Task<LoginResponse> LoginAsync(LoginRequest login);

    public Task<RegistrationResponse> RegistrationAsync(RegistrationRequest registration);
}