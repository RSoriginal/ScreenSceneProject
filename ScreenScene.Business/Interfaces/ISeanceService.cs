using ScreenScene.Business.DTOs;

namespace ScreenScene.Business.Interfaces;

public interface ISeanceService
{
    Task<IEnumerable<SeanceResponse>> GetAllAsync();
    Task<SeanceResponse?> GetByIdAsync(int id);
    Task<IEnumerable<SeanceResponse>> GetByMovieAndDateAsync(int movieId, DateTime date);
    Task<IEnumerable<SeanceResponse>> GetSeancesByMovieAsync(int movieId);
    Task<IEnumerable<SeanceResponse>> GetSeancesByHallAsync(int hallId);
    Task CreateAsync(SeanceCreateRequest seanceRequest);
    Task UpdateAsync(SeanceUpdateRequest seanceRequest);
    Task DeleteAsync(int id);
    Task<IEnumerable<(int Row, int Seat)>> GetAvailableSeatsAsync(int seanceId);
}