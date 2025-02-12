using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ScreenScene.Business.DTOs;
using ScreenScene.Business.DTOs.Actor;
using ScreenScene.Business.Interfaces;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Interfaces;

namespace ScreenScene.Business.Services;

public class SeanceService : ISeanceService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public SeanceService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(SeanceCreateRequest seanceCreateRequest)
    {
        var seance = _mapper.Map<Seance>(seanceCreateRequest);

        await _unitOfWork.Seances.CreateAsync(seance);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Seances.DeleteAsync(id);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<SeanceResponse>> GetAllAsync()
    {
        var seances = await _unitOfWork.Seances.QueryAsync();

        return _mapper.Map<IEnumerable<SeanceResponse>>(seances);
    }

    public async Task<IEnumerable<SeanceResponse>> GetByMovieAndDateAsync(int movieId, DateTime date)
    {
        var seances = new List<Seance>();
        
        var sortSeances = seances.Where(s => s.MovieId == movieId && s.AssignedAt.Date == date);

        return _mapper.Map<IEnumerable<SeanceResponse>>(sortSeances);
    }

    public async Task<SeanceResponse?> GetByIdAsync(int id)
    {
        var seances = await _unitOfWork.Seances.QueryAsync(filter: f => f.Id == id);

        var seance = seances.FirstOrDefault();

        return _mapper.Map<SeanceResponse>(seance);
    }

    public async Task<IEnumerable<SeanceResponse>> GetSeancesByMovieAsync(int movieId)
    {
        var seances = await _unitOfWork.Seances.QueryAsync(filter:
            f => f.MovieId == movieId);
        
        return _mapper.Map<IEnumerable<SeanceResponse>>(seances);
    }

    public async Task<IEnumerable<SeanceResponse>> GetSeancesByHallAsync(int hallId)
    {
        var seances = await _unitOfWork.Seances.QueryAsync(filter:
            f => f.HallId == hallId);
        
        return _mapper.Map<IEnumerable<SeanceResponse>>(seances);
    }
    
    public async Task UpdateAsync(SeanceUpdateRequest seanceUpdateRequest)
    {
        var seance = _mapper.Map<Seance>(seanceUpdateRequest);

        _unitOfWork.Seances.Update(seance);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<(int Row, int Seat)>> GetAvailableSeatsAsync(int seanceId)
    {
        var seances = await _unitOfWork.Seances.QueryAsync(
            q => q.Include(s => s.Hall),
            f => f.Id == seanceId);

        var seance = seances.FirstOrDefault();
        if (seance?.Hall == null)
            throw new Exception("Сеанс или зал не найдены.");

        int rowCount = seance.Hall.RowCount;
        int columnCount = seance.Hall.ColumnCount;

        var occupiedSeats = await _unitOfWork.Tickets.QueryAsync(
            filter: f => f.SeanceId == seanceId);

        var occupiedSet = new HashSet<(int, int)>(
            occupiedSeats.Select(t => (t.RowNumber, t.SeatNumber))
        );

        var allSeats = new List<(int, int)>();
        for (int row = 1; row <= rowCount; row++)
        {
            for (int seat = 1; seat <= columnCount; seat++)
            {
                if (!occupiedSet.Contains((row, seat)))
                {
                    allSeats.Add((row, seat));
                }
            }
        }
        return allSeats;
    }
}