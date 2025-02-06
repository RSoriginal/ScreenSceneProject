using ScreenScene.Business.DTOs.Request;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Business.DTOs.Proposition;

public class PropositionResponse
{
    public string Description {get; set;} = null!;

    public decimal Discount { get; set; }
    
    public int MovieId { get; set; }
    
    public MovieResponse? Movie { get; set; }
    
    public string UserId { get; set; } = null!;

    public ApplicationUser? User { get; set; }
}