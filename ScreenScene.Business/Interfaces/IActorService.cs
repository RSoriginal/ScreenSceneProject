using ScreenScene.Business.DTOs.Actor;

namespace ScreenScene.Business.Interfaces;

public interface IActorService
{
    Task<IEnumerable<ActorResponse>> GetAllAsync();
    Task<ActorResponse?> GetByIdAsync(int id);
    Task CreateAsync(ActorCreateRequest actorRequest);
    Task UpdateAsync(ActorUpdateRequest actorRequest);
    Task DeleteAsync(int id);
}