﻿using Microsoft.EntityFrameworkCore;
using ScreenScene.Data.Interfaces;

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

        public async Task Create(TEntity entity)
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

        public async Task Delete(object id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
                Delete(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
