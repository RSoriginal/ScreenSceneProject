using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers;

[ApiController]
[Route("api/genres")]
public class GenreController : ControllerBase
{
    private readonly ILogger<GenreController> _logger;
    private readonly IGenreService _genreService;

    public GenreController(ILogger<GenreController> logger, IGenreService genreService)
    {
        _logger = logger;
        _genreService = genreService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromBody] GenreCreateRequest genreCreateRequest)
    {
        await _genreService.CreateAsync(genreCreateRequest);

        return StatusCode(201, new { message = "Genre created successfully" });
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await _genreService.DeleteAsync(id);

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
        return Ok(await _genreService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var genre = await _genreService.GetByIdAsync(id);

        return genre is null ? NotFound() : Ok(genre);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] GenreUpdateRequest genreUpdateRequest)
    {
        genreUpdateRequest.Id = id;

        await _genreService.UpdateAsync(genreUpdateRequest);

        return NoContent();
    }
}