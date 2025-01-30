using ScreenScene.Business.DTOs.Request;

namespace ScreenScene.Business.DTOs.Actor;

public class ActorResponse
{
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;

    public IEnumerable<MovieResponse> Movies { get; set; } = [];
}