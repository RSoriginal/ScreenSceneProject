using ScreenScene.Data.Entities;

namespace ScreenScene.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(object id);
        Task Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Delete(object id);
    }
}
