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

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _gradeService.DeleteAsync(id);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _gradeService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _gradeService.GetByIdAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] GradeUpdateRequest gradeUpdateRequest)
    {
        gradeUpdateRequest.Id = id;

        await _gradeService.UpdateAsync(gradeUpdateRequest);

        return Ok();
    }
}