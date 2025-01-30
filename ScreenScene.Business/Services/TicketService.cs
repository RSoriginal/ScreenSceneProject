using ScreenScene.Business.DTOs.Ticket;
using ScreenScene.Business.Interfaces;

namespace ScreenScene.Business.Services;

public class TicketService : ITicketService
{
    public Task<IEnumerable<TicketResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<TicketResponse?> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task Create(TicketRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Update(TicketRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(TicketRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }
}