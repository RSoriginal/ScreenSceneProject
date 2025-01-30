using ScreenScene.Business.DTOs.Actor;
using ScreenScene.Business.DTOs.Ticket;
using ScreenScene.Data.Entities;

namespace ScreenScene.Business.Interfaces;

public interface IActorService
{
    Task<IEnumerable<ActorResponse>> GetAll();
    Task<ActorResponse?> GetById(object id);
    Task Create(ActorCreateRequest entity);
    void Update(ActorUpdateRequest entity);
    Task Delete(object id);
}