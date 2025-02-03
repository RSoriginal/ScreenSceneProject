using ScreenScene.Business.DTOs.Request;

namespace ScreenScene.Business.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<MovieResponse>> GetAllAsync();
    Task<MovieResponse?> GetByIdAsync(int id);
    Task CreateAsync(MovieCreateRequest movieRequest);
    Task UpdateAsync(MovieUpdateRequest movieRequest);
    Task DeleteAsync(int id);
}