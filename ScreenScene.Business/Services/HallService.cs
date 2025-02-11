using AutoMapper;
using ScreenScene.Business.DTOs;
using ScreenScene.Business.DTOs.Hall;
using ScreenScene.Business.Interfaces;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Interfaces;

namespace ScreenScene.Business.Services;

public class HallService : IHallService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public HallService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(HallCreateRequest hallCreateRequest)
    {
        var hall = _mapper.Map<Hall>(hallCreateRequest);
        
        await _unitOfWork.Halls.CreateAsync(hall);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Halls.DeleteAsync(id);
        
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<HallResponse>> GetAllAsync()
    {
        var halls = await _unitOfWork.Halls.QueryAsync();
        
        return _mapper.Map<IEnumerable<HallResponse>>(halls);
    }

    public async Task<HallResponse?> GetByIdAsync(int id)
    {
        var halls = await _unitOfWork.Halls.QueryAsync(filter: f => f.Id == id);

        var hall = halls.FirstOrDefault();
        
        return _mapper.Map<HallResponse>(hall);
    }

    public async Task UpdateAsync(HallUpdateRequest hallRequest)
    {
        var hall = _mapper.Map<Hall>(hallRequest);
        
        _unitOfWork.Halls.Update(hall);
        
        await _unitOfWork.SaveChangesAsync();
    }
}