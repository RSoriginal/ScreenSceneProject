using ScreenScene.Business.DTOs.Grade;
using ScreenScene.Business.Interfaces;

namespace ScreenScene.Business.Services;

public class GradeService : IService<GradeRequest, GradeResponse>
{
    public Task<IEnumerable<GradeResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<GradeResponse?> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task Create(GradeRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Update(GradeRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(GradeRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }
}