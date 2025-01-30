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

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _actorService.DeleteAsync(id);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _actorService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _actorService.GetByIdAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] ActorUpdateRequest actorRequest)
    {
        actorRequest.Id = id;

        await _actorService.UpdateAsync(actorRequest);

        return Ok();
    }
}