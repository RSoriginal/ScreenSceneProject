namespace ScreenScene.Business.DTOs.Request;

public class MovieResponse
{
    public string Title { get; set; } = null!;
    
    public string ImageUrl { get; set; } = null!;
        
    public string Description { get; set; } = null!;
        
    public string TrailerUrl { get; set; } = null!;
        
    public TimeSpan Duration { get; set; }
        
    public DateTime ReleaseDate { get; set; }
    
    public decimal Price { get; set; }
}