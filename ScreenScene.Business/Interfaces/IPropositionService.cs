using ScreenScene.Business.DTOs.Proposition;

namespace ScreenScene.Business.Interfaces;

public interface IPropositionService
{
    Task<IEnumerable<PropositionResponse>> GetAllAsync();
    Task<PropositionResponse?> GetByIdAsync(int id);
    Task CreateAsync(PropositionCreateRequest propositionRequest);
    Task UpdateAsync(PropositionUpdateRequest propositionRequest);
    Task DeleteAsync(int id);
}