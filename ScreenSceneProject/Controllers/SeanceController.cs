using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers;

[ApiController]
[Route("api/seances")]
public class SeanceController : ControllerBase
{
    private readonly ILogger<SeanceController> _logger;
    private readonly ISeanceService _seanceService;
    
    public SeanceController(ILogger<SeanceController> logger, ISeanceService seanceService)
    {
        _logger = logger;
        _seanceService = seanceService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] SeanceCreateRequest seanceCreateRequest)
    {
        await _seanceService.CreateAsync(seanceCreateRequest);

        return StatusCode(201, new { message = "Seance created successfully" });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await _seanceService.DeleteAsync(id);

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
        return Ok(await _seanceService.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var seance = await _seanceService.GetByIdAsync(id);

        return seance is null ? NotFound() : Ok(seance);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SeanceUpdateRequest seanceUpdateRequest)
    {
        seanceUpdateRequest.Id = id;

        await _seanceService.UpdateAsync(seanceUpdateRequest);

        return NoContent();
    }
}