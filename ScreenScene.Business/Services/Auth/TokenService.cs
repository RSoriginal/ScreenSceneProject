using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ScreenScene.Business.DTOs.User;
using ScreenScene.Business.Interfaces;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Business.Services.Auth;

public class TokenService: TokenBase, ITokenService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;

    public TokenService(IMapper mapper, IConfiguration configuration, UserManager<ApplicationUser> userManager):base(configuration)
    {
        _mapper = mapper;
        _configuration = configuration;
        _userManager = userManager;
    }

    public async Task<TokenResponse> RefreshTokenAsync(TokenRequest tokenRequest)
    {
        var principal = GetPrincipalFromExpiredToken(tokenRequest.AccessToken);
        var username = principal.Identity.Name; //this is mapped to the Name claim by default

        var user = await _userManager.FindByNameAsync(username) ?? throw new Exception("Invalid username or email");

        if (user is null || user.RefreshToken != tokenRequest.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new Exception("Invalid client request");

        var newAccessToken = GenerateToken(principal.Claims);
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;

        await _userManager.UpdateAsync(user);

        return new TokenResponse
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };
    }

    public async Task<bool> RevokeTokenAsync(TokenRequest tokenRequest)
    {
        var principal = GetPrincipalFromExpiredToken(tokenRequest.AccessToken);
        var username = principal.Identity.Name; //this is mapped to the Name claim by default

        var user = await _userManager.FindByNameAsync(username) ?? throw new Exception("Invalid username");

        user.RefreshToken = null;

        await _userManager.UpdateAsync(user);

        return true;
    }
}