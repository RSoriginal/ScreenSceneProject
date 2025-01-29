using ScreenScene.Data.Entities;

namespace ScreenScene.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Movie> Movies { get; }
        IGenericRepository<Actor> Actors { get; }
        IGenericRepository<ActorMovie> ActorMovies { get; }
        IGenericRepository<Genre> Genres { get; }
        IGenericRepository<GenreMovie> GenreMovies { get; }
        IGenericRepository<Hall> Halls { get; }
        IGenericRepository<Comment> Comments { get; }
        IGenericRepository<Grade> Grades { get; }
        IGenericRepository<Proposition> Propositions { get; }
        IGenericRepository<Seance> Seances { get; }
        IGenericRepository<Ticket> Tickets { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
