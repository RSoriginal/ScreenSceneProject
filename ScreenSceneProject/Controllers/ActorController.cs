using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs.Actor;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers;

[ApiController]
[Route("api/actors")]
public class ActorController : ControllerBase
{
    private readonly IActorService<ActorRequest, ActorResponse> _actorService;
    
    public ActorController(IActorService<ActorRequest, ActorResponse> actorService)
    {
        _actorService = actorService;
    }
    
    // POST: ~/api/actors
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ActorRequest actorRequest) // get parameter from body (JSON)
    {
        await _actorService.Create(actorRequest);
        return Ok();
    }
    
    // PUT: ~/api/actors
    [HttpPut]
    public  async Task<IActionResult> Edit([FromBody] ActorRequest actorRequest)
    {
        await _actorService.Update(actorRequest);
        return Ok();
    }

    // DELETE: ~/api/actors
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        phoneService.Delete(id);
        return Ok();
    }
}