using System.ComponentModel.DataAnnotations;

namespace ScreenScene.Data.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}