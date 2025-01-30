using ScreenScene.Business.DTOs.Comment;
using ScreenScene.Business.Interfaces;

namespace ScreenScene.Business.Services;

public class CommentService : IService<CommentRequest, CommentResponse>
{
    public Task<IEnumerable<CommentResponse>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<CommentResponse?> GetById(object id)
    {
        throw new NotImplementedException();
    }

    public Task Create(CommentRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Update(CommentRequest entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(CommentRequest entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }
}