using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers;

[ApiController]
[Route("api/halls")]
public class HallController : ControllerBase
{
    private readonly ILogger<HallController> _logger;
    private readonly IHallService _hallService;
    
    public HallController(ILogger<HallController> logger, IHallService hallService)
    {
        _logger = logger;
        _hallService = hallService;
    }
    
    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> CreateAsync([FromBody] HallCreateRequest hallCreateRequest)
    {
        await _hallService.CreateAsync(hallCreateRequest);

        return StatusCode(201, new { message = "Hall created successfully" });
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await _hallService.DeleteAsync(id);

            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _hallService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var hall = await _hallService.GetByIdAsync(id);

        return hall is null ? NotFound() : Ok(hall);
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] HallUpdateRequest hallUpdateRequest)
    {
        hallUpdateRequest.Id = id;

        await _hallService.UpdateAsync(hallUpdateRequest);

        return NoContent();
    }
}