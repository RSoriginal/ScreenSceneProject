using ScreenScene.Business.DTOs.Actor;
using ScreenScene.Business.Interfaces;

namespace ScreenScene.Business.Services;

public class ActorService : IService<ActorRequest, ActorResponse>
{
    public Task<IEnumerable<ActorResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ActorResponse?> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task Create(ActorRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Update(ActorRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(ActorRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }
}