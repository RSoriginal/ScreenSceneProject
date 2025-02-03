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
    public async Task<IActionResult> CreateAsync([FromBody] HallCreateRequest hallCreateRequest)
    {
        await _hallService.CreateAsync(hallCreateRequest);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _hallService.DeleteAsync(id);

        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _hallService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _hallService.GetByIdAsync(id));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] HallUpdateRequest hallUpdateRequest)
    {
        hallUpdateRequest.Id = id;

        await _hallService.UpdateAsync(hallUpdateRequest);

        return Ok();
    }
}