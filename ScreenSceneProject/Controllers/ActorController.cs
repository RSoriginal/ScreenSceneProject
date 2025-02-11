using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs.Actor;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers;

[ApiController]
[Route("api/actors")]
public class ActorController : ControllerBase
{
    private readonly ILogger<ActorController> _logger;
    private readonly IActorService _actorService;

    public ActorController(ILogger<ActorController> logger, IActorService actorService)
    {
        _logger = logger;
        _actorService = actorService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ActorCreateRequest actorRequest)
    {
        await _actorService.CreateAsync(actorRequest);

        return StatusCode(201, new { message = "Actor created successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await _actorService.DeleteAsync(id);

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
        return Ok(await _actorService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var actor = await _actorService.GetByIdAsync(id);

        return actor is null ? NotFound() : Ok(actor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] ActorUpdateRequest actorRequest)
    {
        actorRequest.Id = id;

        await _actorService.UpdateAsync(actorRequest);

        return NoContent();
    }
}