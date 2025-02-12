using AutoMapper;
using ScreenScene.Business.DTOs.Grade;
using ScreenScene.Business.Interfaces;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Interfaces;

namespace ScreenScene.Business.Services;

public class GradeService : IGradeService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GradeService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(GradeCreateRequest gradeCreateRequest)
    {
        var grade = _mapper.Map<Grade>(gradeCreateRequest);
        
        await _unitOfWork.Grades.CreateAsync(grade);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Grades.DeleteAsync(id);
        
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<GradeResponse>> GetAllAsync()
    {
        var grades = await _unitOfWork.Grades.QueryAsync();
        
        return _mapper.Map<IEnumerable<GradeResponse>>(grades);
    }

    public async Task<GradeResponse?> GetByIdAsync(int id)
    {
        var grades = await _unitOfWork.Grades.QueryAsync(filter: f => f.Id == id);

        var grade = grades.FirstOrDefault();
        
        return _mapper.Map<GradeResponse>(grade);
    }
    
    public async Task<double> GetAverageGradeAsync(int id)
    {
        var grades = await _unitOfWork.Grades.QueryAsync(filter: g => g.MovieId == id);
        
        if (!grades.Any())
            return 0.0;
        
        double avgGrades = grades.Average(g => g.Mark);

        return avgGrades;
    }

    public async Task<GradeResponse> GetUserGradeAsync(int movieId, string userId)
    {
        var grades = await _unitOfWork.Grades.QueryAsync(filter: g => g.MovieId == movieId && g.UserId == userId);
        
        var grade = grades.FirstOrDefault();
        
        return _mapper.Map<GradeResponse>(grade);
    }
    
    public Task UpdateAsync(GradeUpdateRequest gradeRequest)
    {
        var grade = _mapper.Map<Grade>(gradeRequest);
        
        _unitOfWork.Grades.Update(grade);
        
        return _unitOfWork.SaveChangesAsync();
    }
}