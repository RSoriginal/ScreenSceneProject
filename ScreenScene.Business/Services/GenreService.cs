using ScreenScene.Business.DTOs;
using ScreenScene.Business.Interfaces;

namespace ScreenScene.Business.Services;

public class GenreService : IGenreService
{
    public Task<IEnumerable<GenreResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<GenreResponse?> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task Create(GenreRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Update(GenreRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(GenreRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }
}