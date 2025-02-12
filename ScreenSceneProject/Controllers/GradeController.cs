using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs.Grade;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers;

[ApiController]
[Route("api/grades")]
public class GradeController : ControllerBase
{
    private readonly ILogger<GradeController> _logger;
    private readonly IGradeService _gradeService;

    public GradeController(ILogger<GradeController> logger, IGradeService gradeService)
    {
        _logger = logger;
        _gradeService = gradeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] GradeCreateRequest gradeCreateRequest)
    {
        await _gradeService.CreateAsync(gradeCreateRequest);

        return StatusCode(201, new { message = "Grade created successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await _gradeService.DeleteAsync(id);

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
        return Ok(await _gradeService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var grade = await _gradeService.GetByIdAsync(id);

        return grade is null ? NotFound() : Ok(grade);
    }

    [HttpGet("movieId/{movieId}")]
    public async Task<double> GetAverageGradeAsync(int movieId)
    {
        return await _gradeService.GetAverageGradeAsync(movieId);
    }
    
    [HttpGet("userId/{userId}")]
    public async Task<GradeResponse?> GetUserGradeAsync(int movieId, string userId)
    {
        return await _gradeService.GetUserGradeAsync(movieId, userId);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] GradeUpdateRequest gradeUpdateRequest)
    {
        gradeUpdateRequest.Id = id;

        await _gradeService.UpdateAsync(gradeUpdateRequest);

        return NoContent();
    }
}