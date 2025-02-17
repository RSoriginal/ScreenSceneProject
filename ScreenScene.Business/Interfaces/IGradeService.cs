using ScreenScene.Business.DTOs.Grade;

namespace ScreenScene.Business.Interfaces;

public interface IGradeService
{
    Task<IEnumerable<GradeResponse>> GetAllAsync();
    Task<GradeResponse?> GetByIdAsync(int id);
    Task<double> GetAverageGradeAsync(int movieId);
    Task<GradeResponse> GetUserGradeAsync(int movieId, string userId);
    Task CreateAsync(GradeCreateRequest gradeRequest);
    Task UpdateAsync(GradeUpdateRequest gradeRequest);
    Task DeleteAsync(int id);
}