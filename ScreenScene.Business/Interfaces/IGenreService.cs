using ScreenScene.Business.DTOs;

namespace ScreenScene.Business.Interfaces;

public interface IGenreService
{
    Task<IEnumerable<GenreResponse>> GetAllAsync();
    Task<GenreResponse?> GetByIdAsync(int id);
    Task CreateAsync(GenreCreateRequest genreRequest);
    Task UpdateAsync(GenreUpdateRequest genreRequest);
    Task DeleteAsync(int id);
}