using ScreenScene.Data.Entities;
using ScreenScene.Data.Entities.Auth;

namespace ScreenScene.Business.DTOs.Proposition;

public class PropositionResponse
{
    public string Description {get; set;} = null!;

    public decimal Discount { get; set; }
    
    public int MovieId { get; set; }
    
    public Movie? Movie { get; set; }
    
    public string UserId { get; set; }
    
    public ApplicationUser? User { get; set; }
}