using ScreenScene.Business.DTOs;
using ScreenScene.Business.DTOs.Hall;

namespace ScreenScene.Business.Interfaces;

public interface IHallService
{
    Task<IEnumerable<HallResponse>> GetAllAsync();
    Task<HallResponse?> GetByIdAsync(int id);
    Task CreateAsync(HallCreateRequest hallRequest);
    Task UpdateAsync(HallUpdateRequest hallRequest);
    Task DeleteAsync(int id);
}