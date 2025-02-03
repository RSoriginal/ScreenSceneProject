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
    public async Task<IActionResult> CreateAsync([FromBody] GenreCreateRequest genreCreateRequest)
    {
        await _genreService.CreateAsync(genreCreateRequest);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _genreService.DeleteAsync(id);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _genreService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _genreService.GetByIdAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] GenreUpdateRequest genreUpdateRequest)
    {
        genreUpdateRequest.Id = id;

        await _genreService.UpdateAsync(genreUpdateRequest);

        return Ok();
    }
}