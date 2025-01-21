using Microsoft.AspNetCore.Identity;

namespace ScreenScene.Data.Entities.Auth;

public class ApplicationUser : IdentityUser
{
    public IEnumerable<Ticket> Tickets { get; set; } = [];
    
    public IEnumerable<Proposition> Propositions { get; set; } = [];
}