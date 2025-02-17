using ScreenScene.Business.DTOs.Comment;

namespace ScreenScene.Business.Interfaces;

public interface ICommentService
{
    Task<IEnumerable<CommentResponse>> GetAllAsync();
    Task<CommentResponse?> GetByIdAsync(int id);
    Task<IEnumerable<CommentResponse>> GetCommentsByMovieIdAsync(int movieId);
    Task<IEnumerable<CommentResponse>> GetUserCommentsAsync(string userId); 
    Task CreateAsync(CommentCreateRequest commentRequest);
    Task UpdateAsync(CommentUpdateRequest commentRequest);
    Task DeleteAsync(int id);  
}