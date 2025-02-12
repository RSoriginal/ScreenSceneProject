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

    [HttpGet("movie/{movieId}/date/{date}")]
    public async Task<IActionResult> GetByMovieAndDateAsync(int movieId, DateTime date)
    {
        var seances = await _seanceService.GetByMovieAndDateAsync(movieId, date);

        return Ok(seances);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var seance = await _seanceService.GetByIdAsync(id);

        return seance is null ? NotFound() : Ok(seance);
    }
    
    [HttpGet("movieId/{movieId}")]
    public async Task<IActionResult> GetSeancesByMovieAsync(int movieId)
    {
        if (movieId <= 0)
        {
            return BadRequest("Movie ID must be greater than 0.");
        }

        var seances = await _seanceService.GetSeancesByMovieAsync(movieId);

        return seances is not null && seances.Any() ? Ok(seances) : NotFound();
    }
    
    [HttpGet("hallId/{hallId}")]
    public async Task<IActionResult> GetSeancesByHallAsync(int hallId)
    {
        if (hallId <= 0)
        {
            return BadRequest("Movie ID must be greater than 0.");
        }

        var seances = await _seanceService.GetSeancesByHallAsync(hallId);

        return seances is not null && seances.Any() ? Ok(seances) : NotFound();
    }
    
    [HttpGet("available-seats/{seanceId}")]
    public async Task<IActionResult> GetAvailableSeatsAsync(int seanceId)
    {
        if (seanceId <= 0)
        {
            return BadRequest("Movie ID must be greater than 0.");
        }

        var seances = await _seanceService.GetAvailableSeatsAsync(seanceId);

        return seances is not null && seances.Any() ? Ok(seances) : NotFound();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] SeanceUpdateRequest seanceUpdateRequest)
    {
        seanceUpdateRequest.Id = id;

        await _seanceService.UpdateAsync(seanceUpdateRequest);

        return NoContent();
    }
}