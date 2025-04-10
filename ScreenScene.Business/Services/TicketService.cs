using AutoMapper;
using ScreenScene.Business.DTOs.Ticket;
using ScreenScene.Business.Interfaces;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Interfaces;

namespace ScreenScene.Business.Services;

public class TicketService : ITicketService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TicketService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(TicketCreateRequest ticketCreateRequest)
    {
        var ticket = _mapper.Map<Ticket>(ticketCreateRequest);

        await _unitOfWork.Tickets.CreateAsync(ticket);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Tickets.DeleteAsync(id);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<TicketResponse>> GetAllAsync()
    {
        var tickets = await _unitOfWork.Tickets.QueryAsync();

        return _mapper.Map<IEnumerable<TicketResponse>>(tickets);
    }

    public async Task<TicketResponse?> GetByIdAsync(int id)
    {
        var tickets = await _unitOfWork.Tickets.QueryAsync(filter: f => f.Id == id);

        var ticket = tickets.FirstOrDefault();

        return _mapper.Map<TicketResponse>(ticket);
    }

    public async Task<IEnumerable<TicketResponse>> GetUserTicketsAsync(string userId)
    {
        var tickets = await _unitOfWork.Tickets.QueryAsync(filter: f => f.UserId == userId);
        
        return _mapper.Map<IEnumerable<TicketResponse>>(tickets);
    }
    
    public async Task UpdateAsync(TicketUpdateRequest ticketUpdateRequest)
    {
        var ticket = _mapper.Map<Ticket>(ticketUpdateRequest);

        _unitOfWork.Tickets.Update(ticket);

        await _unitOfWork.SaveChangesAsync();
    }
}