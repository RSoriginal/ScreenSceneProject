using AutoMapper;
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
        var seances = await _unitOfWork.Seances.GetAllAsync();

        return _mapper.Map<IEnumerable<SeanceResponse>>(seances);
    }

    public async Task<SeanceResponse?> GetByIdAsync(int id)
    {
        var seance = await _unitOfWork.Seances.GetByIdAsync(id);

        return _mapper.Map<SeanceResponse>(seance);
    }

    public async Task UpdateAsync(SeanceUpdateRequest seanceUpdateRequest)
    {
        var seance = _mapper.Map<Seance>(seanceUpdateRequest);

        _unitOfWork.Seances.Update(seance);

        await _unitOfWork.SaveChangesAsync();
    }
}