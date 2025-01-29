using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ScreenScene.Data.Entities;

namespace ScreenScene.Data.Interfaces;

public interface IScreenSceneDbContext : IDisposable
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<ActorMovie> ActorMovies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<GenreMovie> GenreMovies { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Proposition> Propositions { get; set; }
    public DbSet<Seance> Seances { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
}