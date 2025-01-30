using ScreenScene.Business.DTOs.Proposition;
using ScreenScene.Business.Interfaces;

namespace ScreenScene.Business.Services;

public class PropositionService : IService<PropositionRequest, PropositionResponse>
{
    public Task<IEnumerable<PropositionResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<PropositionResponse?> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task Create(PropositionRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Update(PropositionRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(PropositionRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }
}