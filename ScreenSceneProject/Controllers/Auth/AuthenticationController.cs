using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs.User;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers.Auth;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _service;

    public AuthenticationController(IAuthenticationService service)
    {
        _service = service;
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LoginAsync([FromBody]LoginRequest request)
    {
        try
        {
            return Ok(await _service.LoginAsync(request));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    [Route("registration")]
    public async Task<IActionResult> RegistrationAsync([FromBody]RegistrationRequest request)
    {
        try
        {
            await _service.RegistrationAsync(request);

            return StatusCode(201, new { message = "Actor created successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> GetCurrentUserAsync()
    {
        var user = await _service.GetUserAsync(User);
        if (user == null)
            return NotFound(new { message = "User not found" });

        return Ok(user);
    }
}