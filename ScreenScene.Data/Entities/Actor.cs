using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScreenScene.Data.Entities;

[Table("Actors")]
public class Actor : BaseEntity
{
    [Required]
    [StringLength(255)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(255)]
    public string LastName { get; set; } = null!;
    
    public IEnumerable<ActorMovie> ActorMovies { get; set; } = [];
}