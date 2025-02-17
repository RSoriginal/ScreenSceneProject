using ScreenScene.Business.DTOs.Request;

namespace ScreenScene.Business.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<MovieResponse>> GetAllAsync();
    Task<IEnumerable<MovieResponse>> GetCurrentMoviesAsync();
    Task<IEnumerable<MovieResponse>> GetUpcomingMoviesAsync();
    Task<IEnumerable<MovieResponse>> GetByAnyGenresAsync(List<int> genreIds);
    Task<IEnumerable<MovieResponse>> GetByAllGenresAsync(List<int> genreIds);
    Task<(IEnumerable<MovieResponse> Movies, IEnumerable<double> AverageGrades)> GetTopRatedMoviesAsync(int count);
    Task<MovieResponse?> GetByIdAsync(int id);
    Task CreateAsync(MovieCreateRequest movieRequest);
    Task UpdateAsync(MovieUpdateRequest movieRequest);
    Task DeleteAsync(int id);
}