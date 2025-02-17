using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs.Comment;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers;

[ApiController]
[Route("api/comments")]
public class CommentController : ControllerBase
{
    private readonly ILogger<CommentController> _logger;
    private readonly ICommentService _commentService;
    
    public CommentController(ILogger<CommentController> logger, ICommentService commentService)
    {
        _logger = logger;
        _commentService = commentService;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromBody] CommentCreateRequest commentCreateRequest)
    {
        await _commentService.CreateAsync(commentCreateRequest);

        return StatusCode(201, new { message = "Comment created successfully" });
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await _commentService.DeleteAsync(id);

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
        return Ok(await _commentService.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var comment = await _commentService.GetByIdAsync(id);

        return comment is null ? NotFound() : Ok(comment);
    }

    [HttpGet("movieId/{movieId}")]
    public async Task<IActionResult> GetCommentsByMovieIdAsync(int movieId)
    {
        var comments = await _commentService.GetCommentsByMovieIdAsync(movieId);
        
        return comments is null ? NotFound() : Ok(comments);
    }
    
    [HttpGet("userId/{userId}")]
    [Authorize]
    public async Task<IActionResult> GetUserCommentsAsync(string userId)
    {
        var comments = await _commentService.GetUserCommentsAsync(userId);
        
        return comments is null ? NotFound() : Ok(comments);
    }
    
    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] CommentUpdateRequest commentUpdateRequest)
    {
        commentUpdateRequest.Id = id;

        await _commentService.UpdateAsync(commentUpdateRequest);

        return NoContent();
    }
}