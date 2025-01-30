using ScreenScene.Business.DTOs.Request;
using ScreenScene.Business.Interfaces;

namespace ScreenScene.Business.Services;

public class MovieService : IMovieService
{
    public Task<IEnumerable<MovieResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<MovieResponse?> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task Create(MovieRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Update(MovieRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(MovieRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }
}