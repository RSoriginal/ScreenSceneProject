using Microsoft.AspNetCore.Identity;

namespace ScreenScene.Data.Entities.Auth;

public class ApplicationUser : IdentityUser
{
    public IEnumerable<Ticket> Tickets { get; set; } = [];
    
    public IEnumerable<Proposition> Propositions { get; set; } = [];
    
    public IEnumerable<Grade> Grades { get; set; } = [];

    public IEnumerable<Comment> Comments { get; set; } = [];
    
    public string? RefreshToken { get; set; }
    
    public DateTime RefreshTokenExpiryTime { get; set; }
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
} 