using Microsoft.AspNetCore.Identity;

namespace ScreenScene.Data.Entities.Auth;

public class ApplicationUser : IdentityUser
{
    public IEnumerable<Ticket> Tickets { get; set; } = [];
    
    public IEnumerable<Proposition> Propositions { get; set; } = [];
    
    public IEnumerable<Grade> Grades { get; set; } = [];

    public IEnumerable<Comment> Comments { get; set; } = [];
}