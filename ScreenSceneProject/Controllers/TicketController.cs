using Microsoft.AspNetCore.Mvc;
using ScreenScene.Business.DTOs.Ticket;
using ScreenScene.Business.Interfaces;

namespace ScreenSceneProject.Controllers;

[ApiController]
[Route("api/tickets")]
public class TicketController : ControllerBase
{
    private readonly ILogger<TicketController> _logger;
    private readonly ITicketService _ticketService;
    
    public TicketController(ILogger<TicketController> logger, ITicketService ticketService)
    {
        _logger = logger;
        _ticketService = ticketService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] TicketCreateRequest ticketCreateRequest)
    {
        await _ticketService.CreateAsync(ticketCreateRequest);

        return StatusCode(201, new { message = "Ticket created successfully" });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        try
        {
            await _ticketService.DeleteAsync(id);

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
        return Ok(await _ticketService.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var ticket = await _ticketService.GetByIdAsync(id);

        return ticket is null ? NotFound() : Ok(ticket);
    }
      
    [HttpGet("user-tickets/{id}")]
    public async Task<IActionResult> GetUserTicketsAsync(string id)
    {
        var ticket = await _ticketService.GetUserTicketsAsync(id);

        return ticket is null ? NotFound() : Ok(ticket);
    }
        
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] TicketUpdateRequest ticketUpdateRequest)
    {
        ticketUpdateRequest.Id = id;

        await _ticketService.UpdateAsync(ticketUpdateRequest);

        return NoContent();
    }
}