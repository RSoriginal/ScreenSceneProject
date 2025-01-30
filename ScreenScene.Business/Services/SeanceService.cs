using ScreenScene.Business.DTOs;
using ScreenScene.Business.Interfaces;

namespace ScreenScene.Business.Services;

public class SeanceService : ISeanceService
{
    public Task<IEnumerable<SeanceResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<SeanceResponse?> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task Create(SeanceRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Update(SeanceRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(SeanceRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }
}