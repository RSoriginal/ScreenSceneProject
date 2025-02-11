using ScreenScene.Business.DTOs;

namespace ScreenScene.Business.Interfaces;

public interface ISeanceService
{
    Task<IEnumerable<SeanceResponse>> GetAllAsync();
    Task<SeanceResponse?> GetByIdAsync(int id);
    Task<IEnumerable<SeanceResponse>> GetByMovieAndDateAsync(int movieId, DateTime date);
    Task CreateAsync(SeanceCreateRequest seanceRequest);
    Task UpdateAsync(SeanceUpdateRequest seanceRequest);
    Task DeleteAsync(int id);
}