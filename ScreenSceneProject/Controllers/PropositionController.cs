using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs.Proposition;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers;

[ApiController]
[Route("api/propositions")]
public class PropositionController : ControllerBase
{
    private readonly ILogger<PropositionController> _logger;
    private readonly IPropositionService _propositionService;
    
    public PropositionController(ILogger<PropositionController> logger, IPropositionService propositionService)
    {
        _logger = logger;
        _propositionService = propositionService;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromBody] PropositionCreateRequest propositionCreateRequest)
    {
        await _propositionService.CreateAsync(propositionCreateRequest);

        return StatusCode(201, new { message = "Proposition created successfully" });
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await _propositionService.DeleteAsync(id);

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
        return Ok(await _propositionService.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var proposition = await _propositionService.GetByIdAsync(id);

        return proposition is null ? NotFound() : Ok(proposition);
    }
     
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] PropositionUpdateRequest propositionUpdateRequest)
    {
        propositionUpdateRequest.Id = id;

        await _propositionService.UpdateAsync(propositionUpdateRequest);

        return NoContent();
    }
}