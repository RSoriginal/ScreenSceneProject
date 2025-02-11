using Microsoft.EntityFrameworkCore;
using ScreenScene.Data.Interfaces;
using System.Linq.Expressions;

namespace ScreenScene.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IScreenSceneDbContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(IScreenSceneDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException($"Entity with id {id} not found."); 

            if (entity != null)
                Delete(entity);
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeNavigations,
            Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy)
        {
            var query = _dbSet.AsNoTracking();

            if (includeNavigations is not null)
                query = includeNavigations(query);

            if (filter is not null)
                query = query.Where(filter);

            return await (orderBy?.Invoke(query) ?? query).ToListAsync();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
