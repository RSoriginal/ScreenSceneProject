using AutoMapper;
using ScreenScene.Business.DTOs.Proposition;
using ScreenScene.Business.Interfaces;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Interfaces;

namespace ScreenScene.Business.Services;

public class PropositionService : IPropositionService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public PropositionService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task CreateAsync(PropositionCreateRequest propositionCreateRequest)
    {
        var proposition = _mapper.Map<Proposition>(propositionCreateRequest);

        await _unitOfWork.Propositions.CreateAsync(proposition);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Propositions.DeleteAsync(id);

        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<PropositionResponse>> GetAllAsync()
    {
        var propositions = await _unitOfWork.Propositions.QueryAsync();

        return _mapper.Map<IEnumerable<PropositionResponse>>(propositions);
    }
    
    public async Task<PropositionResponse?> GetByIdAsync(int id)
    {
        var propositions = await _unitOfWork.Propositions.QueryAsync(filter: f => f.Id == id);

        var proposition = propositions.FirstOrDefault();

        return _mapper.Map<PropositionResponse>(proposition);
    }
    
    public async Task UpdateAsync(PropositionUpdateRequest propositionUpdateRequest)
    {
        var proposition = _mapper.Map<Proposition>(propositionUpdateRequest);

        _unitOfWork.Propositions.Update(proposition);

        await _unitOfWork.SaveChangesAsync();
    }
}