using ScreenScene.Business.DTOs.Ticket;

namespace ScreenScene.Business.Interfaces;

public interface ITicketService
{
    Task<IEnumerable<TicketResponse>> GetAllAsync();
    Task<TicketResponse?> GetByIdAsync(int id);
    Task<IEnumerable<TicketResponse>> GetUserTicketsAsync(string userId);
    Task CreateAsync(TicketCreateRequest ticketRequest);
    Task UpdateAsync(TicketUpdateRequest ticketRequest);
    Task DeleteAsync(int id);
}