using System.ComponentModel.DataAnnotations;
using ScreenScene.Data.Entities;

namespace ScreenScene.Business.DTOs;

public class GenreRequest
{
    [Required(ErrorMessage = "Genre name is required")]
    [StringLength(55)]
    public string Name { get; set; } = null!;
}