using AutoMapper;
using ScreenScene.Business.DTOs.Actor;
using ScreenScene.Business.Interfaces;
using ScreenScene.Data.Entities;
using ScreenScene.Data.Interfaces;

namespace ScreenScene.Business.Services;

public class ActorService : IActorService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ActorService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(ActorCreateRequest actorRequest)
    {
        var actor = _mapper.Map<Actor>(actorRequest);

        await _unitOfWork.Actors.CreateAsync(actor);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _unitOfWork.Actors.DeleteAsync(id);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<ActorResponse>> GetAllAsync()
    {
        var actors = await _unitOfWork.Actors.GetAllAsync();

        return _mapper.Map<IEnumerable<ActorResponse>>(actors);
    }

    public async Task<ActorResponse?> GetByIdAsync(int id)
    {
        var actor = await _unitOfWork.Actors.GetByIdAsync(id);

        return _mapper.Map<ActorResponse>(actor);
    }

    public async Task UpdateAsync(ActorUpdateRequest actorRequest)
    {
        var actor = _mapper.Map<Actor>(actorRequest);

        _unitOfWork.Actors.Update(actor);

        await _unitOfWork.SaveChangesAsync();
    }
}