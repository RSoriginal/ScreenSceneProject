using ScreenScene.Data.Entities;
using ScreenScene.Data.Entities.Auth;
using ScreenScene.Data.Interfaces;

namespace ScreenScene.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IScreenSceneDbContext _context;

        private readonly Dictionary<Type, object> _repositories = [];

        public UnitOfWork(IScreenSceneDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<ApplicationUser> Users => GetRepository<ApplicationUser>();

        public IGenericRepository<Movie> Movies => GetRepository<Movie>();

        public IGenericRepository<Actor> Actors => GetRepository<Actor>();

        //public IGenericRepository<ActorMovie> ActorMovies => GetRepository<ActorMovie>();

        public IGenericRepository<Genre> Genres => GetRepository<Genre>();

        //public IGenericRepository<GenreMovie> GenreMovies => GetRepository<GenreMovie>();

        public IGenericRepository<Hall> Halls => GetRepository<Hall>();

        public IGenericRepository<Comment> Comments => GetRepository<Comment>();

        public IGenericRepository<Grade> Grades => GetRepository<Grade>();

        public IGenericRepository<Proposition> Propositions => GetRepository<Proposition>();

        public IGenericRepository<Seance> Seances => GetRepository<Seance>();

        public IGenericRepository<Ticket> Tickets => GetRepository<Ticket>();

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IGenericRepository<T>)_repositories[typeof(T)];
            }

            var repository = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repository);

            return repository;
        }
    }
}
