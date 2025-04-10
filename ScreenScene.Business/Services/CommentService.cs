using AutoMapper;
using ScreenScene.Business.DTOs.Comment;
using ScreenScene.Business.Interfaces;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Interfaces;

namespace ScreenScene.Business.Services;

public class CommentService : ICommentService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CommentService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CommentCreateRequest commentCreateRequest)
    {
        var comment = _mapper.Map<Comment>(commentCreateRequest);
        
        await _unitOfWork.Comments.CreateAsync(comment);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Comments.DeleteAsync(id);
        
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<CommentResponse>> GetAllAsync()
    {
        var comments = await _unitOfWork.Comments.QueryAsync();
        
        return _mapper.Map<IEnumerable<CommentResponse>>(comments);
    }

    public async Task<CommentResponse?> GetByIdAsync(int id)
    {
        var comments = await _unitOfWork.Comments.QueryAsync(filter: f => f.Id == id);

        var comment = comments.FirstOrDefault();
        
        return _mapper.Map<CommentResponse>(comment);
    }

    public async Task<IEnumerable<CommentResponse>> GetCommentsByMovieIdAsync(int movieId)
    {
        var comments = await _unitOfWork.Comments.QueryAsync(filter: f => f.MovieId == movieId );
        
        return _mapper.Map<IEnumerable<CommentResponse>>(comments);
    }

    public async Task<IEnumerable<CommentResponse>> GetUserCommentsAsync(string userId)
    {
        var comments = await _unitOfWork.Comments.QueryAsync(filter: f => f.UserId == userId);
        
        return _mapper.Map<IEnumerable<CommentResponse>>(comments);
    }
    
    public async Task UpdateAsync(CommentUpdateRequest commentUpdateRequest)
    {
        var comment = _mapper.Map<Comment>(commentUpdateRequest);
        
        _unitOfWork.Comments.Update(comment);
        
        await _unitOfWork.SaveChangesAsync();
    }
}