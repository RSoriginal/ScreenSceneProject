using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ScreenScene.Business.DTOs.User;
using ScreenScene.Business.Interfaces;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Business.Services.Auth;

public class AuthenticationService : TokenBase, IAuthenticationService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthenticationService(IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : base(configuration)
    {
        _configuration = configuration;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<ApplicationUser?> GetUserAsync(ClaimsPrincipal userPrincipal)
    {
        var userName = userPrincipal.Identity?.Name ?? userPrincipal.FindFirst(ClaimTypes.Name)?.Value;

        if (!string.IsNullOrEmpty(userName))
        {
            return await _userManager.FindByNameAsync(userName);
        }

        return null;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest login)
    {
        var user = await _userManager.FindByNameAsync(login.UserName) ?? throw new Exception("Invalid username or password");

        if (!await _userManager.CheckPasswordAsync(user, login.Password)) throw new Exception("Invalid password or username");

        var userRoles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var token = GenerateToken(authClaims);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(Convert.ToInt16(_configuration["JWTKey:RefreshTokenExpiryTimeInDay"]));

        await _userManager.UpdateAsync(user);
        
        return new LoginResponse
        {
            UserId = user.Id,
            UserName = user.UserName,
            Token = new TokenResponse
            {
                AccessToken = token,
                RefreshToken = refreshToken
            }
        };
    }

    public async Task RegistrationAsync(RegistrationRequest registration)
    {
        var userExists = await _userManager.FindByNameAsync(registration.UserName);

        if (userExists != null) throw new Exception("User already exists");

        var user = new ApplicationUser
        {
            Email = registration.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = registration.UserName,
            FirstName = registration.FirstName,
            LastName = registration.LastName,
        };

        var createdUserResult = await _userManager.CreateAsync(user, registration.Password);

        if (!createdUserResult.Succeeded) throw new Exception("User creation failed! Please check user details and try again.");

        var role = registration.Role.ToLower();

        if (!await _roleManager.RoleExistsAsync(role))
        {
            await _roleManager.CreateAsync(new IdentityRole(role));
        }

        if (await _roleManager.RoleExistsAsync(role))
        {
            await _userManager.AddToRoleAsync(user, role);
        }
    }
}