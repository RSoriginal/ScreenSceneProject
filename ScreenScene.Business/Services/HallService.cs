using ScreenScene.Business.DTOs;
using ScreenScene.Business.Interfaces;

namespace ScreenScene.Business.Services;

public class HallService : IHallService
{
    public Task<IEnumerable<HallResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<HallResponse?> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task Create(HallRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Update(HallRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(HallRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }
}