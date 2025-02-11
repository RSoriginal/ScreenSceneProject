using AutoMapper;
using ScreenScene.Business.DTOs;
using ScreenScene.Business.DTOs.Grade;
using ScreenScene.Business.Interfaces;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Interfaces;

namespace ScreenScene.Business.Services;

public class GenreService : IGenreService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GenreService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(GenreCreateRequest genreCreateRequest)
    {
        var genre = _mapper.Map<Genre>(genreCreateRequest);
        
        await _unitOfWork.Genres.CreateAsync(genre);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Genres.DeleteAsync(id);
        
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<GenreResponse>> GetAllAsync()
    {
        var genres = await _unitOfWork.Genres.QueryAsync();
        
        return _mapper.Map<IEnumerable<GenreResponse>>(genres);
    }

    public async Task<GenreResponse?> GetByIdAsync(int id)
    {
        var genres = await _unitOfWork.Genres.QueryAsync(filter: f => f.Id == id);

        var genre = genres.FirstOrDefault();
        
        return _mapper.Map<GenreResponse>(genre);
    }

    public async Task UpdateAsync(GenreUpdateRequest genreRequest)
    {
       var genre = _mapper.Map<Genre>(genreRequest);
       
       _unitOfWork.Genres.Update(genre);
       
       await _unitOfWork.SaveChangesAsync();
    }
}