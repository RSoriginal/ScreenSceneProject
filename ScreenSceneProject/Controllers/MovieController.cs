using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> CreateAsync([FromBody] MovieCreateRequest movieCreateRequest)
    {
        await _movieService.CreateAsync(movieCreateRequest);

        return StatusCode(201, new { message = "Movie created successfully" });
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await _movieService.DeleteAsync(id);

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
        return Ok(await _movieService.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var movie = await _movieService.GetByIdAsync(id);

        return movie is null ? NotFound() : Ok(movie);
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] MovieUpdateRequest movieUpdateRequest)
    {
        movieUpdateRequest.Id = id;

        await _movieService.UpdateAsync(movieUpdateRequest);

        return NoContent();
    }

    [HttpGet("current")]
    public async Task<IActionResult> GetCurrentMoviesAsync()
    {
        return Ok(await _movieService.GetCurrentMoviesAsync());
    }

    [HttpGet("by-any-genres")]
    public async Task<IActionResult> GetByAnyGenresAsync([FromQuery] List<int> genreIds)
    {
        if (genreIds == null || genreIds.Count == 0)
        {
            return BadRequest("Genre IDs are required.");
        }

        return Ok(await _movieService.GetByAnyGenresAsync(genreIds));
    }
    
    [HttpGet("by-all-genres")]
    public async Task<IActionResult> GetByAllGenresAsync([FromQuery] List<int> genreIds)
    {
        if (genreIds == null || genreIds.Count == 0)
        {
            return BadRequest("Genre IDs are required.");
        }

        return Ok(await _movieService.GetByAllGenresAsync(genreIds));
    }
    
    [HttpGet("upcoming")]
    public async Task<IActionResult> GetUpcomingMoviesAsync()
    {
        return Ok(await _movieService.GetUpcomingMoviesAsync());
    }
    
}