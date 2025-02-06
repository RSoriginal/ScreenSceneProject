using ScreenScene.Business.DTOs.Request;

namespace ScreenScene.Business.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<MovieResponse>> GetAllAsync();
    Task<IEnumerable<MovieResponse>> GetCurrentMoviesAsync();
    Task<IEnumerable<MovieResponse>> GetUpcomingMoviesAsync();
    Task<MovieResponse?> GetByIdAsync(int id);
    Task CreateAsync(MovieCreateRequest movieRequest);
    Task UpdateAsync(MovieUpdateRequest movieRequest);
    Task DeleteAsync(int id);
}