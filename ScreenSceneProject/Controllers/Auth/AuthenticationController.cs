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
            return Ok(await _service.RegistrationAsync(request));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}