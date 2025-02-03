using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs.Request;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MovieController> _logger;
    private readonly IMovieService _movieService;
    
    public MovieController(ILogger<MovieController> logger, IMovieService movieService)
    {
        _logger = logger;
        _movieService = movieService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] MovieCreateRequest movieCreateRequest)
    {
        await _movieService.CreateAsync(movieCreateRequest);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _movieService.DeleteAsync(id);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _movieService.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _movieService.GetByIdAsync(id));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] MovieUpdateRequest movieUpdateRequest)
    {
        movieUpdateRequest.Id = id;

        await _movieService.UpdateAsync(movieUpdateRequest);

        return Ok();
    }
}