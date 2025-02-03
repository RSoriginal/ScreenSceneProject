using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ScreenScene.Data.Entities;

namespace ScreenScene.Data.Interfaces;

public interface IScreenSceneDbContext : IDisposable
{
    DbSet<Movie> Movies { get; set; }
    DbSet<Actor> Actors { get; set; }
    DbSet<ActorMovie> ActorMovies { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<GenreMovie> GenreMovies { get; set; }
    DbSet<Comment> Comments { get; set; }
    DbSet<Grade> Grades { get; set; }
    DbSet<Hall> Halls { get; set; }
    DbSet<Proposition> Propositions { get; set; }
    DbSet<Seance> Seances { get; set; }
    DbSet<Ticket> Tickets { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
}