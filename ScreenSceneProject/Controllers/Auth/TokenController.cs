using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs.User;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers.Auth;

[ApiController]
[Route("api/token")]
public class TokenController : ControllerBase
{
    private readonly ITokenService _service;

    public TokenController(ITokenService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("refresh")]
    public async Task<IActionResult> RefreshTokenAsync([FromBody]TokenRequest token)
    {
        try
        {
            return Ok(await _service.RefreshTokenAsync(token));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost, Authorize]
    [Route("revoke")]
    public async Task<IActionResult> RevokeTokenAsync([FromBody]TokenRequest token)
    {
        try
        {
            return Ok(await _service.RevokeTokenAsync(token));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}