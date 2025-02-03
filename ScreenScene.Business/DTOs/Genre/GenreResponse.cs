using ScreenScene.Business.DTOs.Request;

namespace ScreenScene.Business.DTOs;

public class GenreResponse
{
    public string Name { get; set; } = null!;
    public IEnumerable<MovieResponse> Movies { get; set; } = [];
}