﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ScreenScene.Data.Entities;

[Table("Genres")]
[Index(nameof(Name), IsUnique = true)]
public class Genre : BaseEntity
{
    [Required]
    [StringLength(55)]
    public string Name { get; set; } = null!;

    public ICollection<GenreMovie> GenreMovies { get; set; } = [];
}