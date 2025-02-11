using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScreenScene.Business.DTOs.Request;
using ScreenScene.Business.Interfaces;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Interfaces;

namespace ScreenScene.Business.Services;

public class MovieService : IMovieService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public MovieService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<MovieResponse>> GetCurrentMoviesAsync()
    {
        var movies = new List<Movie>();
        //var movies = await _unitOfWork.Movies.GetAllAsync();
        var currentMovies = movies.Where(m => m.ReleaseDate <= DateTime.UtcNow);

        return _mapper.Map<IEnumerable<MovieResponse>>(currentMovies);
    }

    public async Task<IEnumerable<MovieResponse>> GetUpcomingMoviesAsync()
    {
        var movies = new List<Movie>();
        //var movies = await _unitOfWork.Movies.GetAllAsync();
        var upcomingMovies = movies.Where(m => m.ReleaseDate > DateTime.UtcNow);

        return _mapper.Map<IEnumerable<MovieResponse>>(upcomingMovies);
    }

    public async Task CreateAsync(MovieCreateRequest createRequest)
    {
        var movie = _mapper.Map<Movie>(createRequest);

        await _unitOfWork.Movies.CreateAsync(movie);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Movies.DeleteAsync(id);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<MovieResponse>> GetAllAsync()
    {
        var movies = await _unitOfWork.Movies.QueryAsync(
            q => q.Include(m => m.ActorMovies).ThenInclude(am => am.Actor)
                  .Include(m => m.GenreMovies).ThenInclude(gm => gm.Genre)
                  .AsSplitQuery());

        return _mapper.Map<IEnumerable<MovieResponse>>(movies);
    }

    public async Task<MovieResponse?> GetByIdAsync(int id)
    {
        var movies = await _unitOfWork.Movies.QueryAsync(
            q => q.Include(m => m.ActorMovies).ThenInclude(am => am.Actor)
                  .Include(m => m.GenreMovies).ThenInclude(gm => gm.Genre)
                  .AsSplitQuery(),
            f => f.Id == id);

        var movie = movies.FirstOrDefault();

        return _mapper.Map<MovieResponse>(movie);
    }

    public async Task UpdateAsync(MovieUpdateRequest updateRequest)
    {
        var movie = _mapper.Map<Movie>(updateRequest);

        _unitOfWork.Movies.Update(movie);

        await _unitOfWork.SaveChangesAsync();
    }
}