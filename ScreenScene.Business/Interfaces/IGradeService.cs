using ScreenScene.Business.DTOs;
using ScreenScene.Business.DTOs.Grade;

namespace ScreenScene.Business.Interfaces;

public interface IGradeService
{
    Task<IEnumerable<GradeResponse>> GetAllAsync();
    Task<GradeResponse?> GetByIdAsync(int id);
    Task CreateAsync(GradeCreateRequest gradeRequest);
    Task UpdateAsync(GradeUpdateRequest gradeRequest);
    Task DeleteAsync(int id);
}