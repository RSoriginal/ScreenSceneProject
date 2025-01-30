namespace ScreenScene.Business.Interfaces;

public interface IService
{
    Task<IEnumerable<TResponse>> GetAll() where TResponse : class;
    Task<TResponse?> GetById(object id);
    Task Create(TRequest entity);
    void Update(TRequest entity);
    void Delete(TRequest entity);
    Task Delete(object id);
}