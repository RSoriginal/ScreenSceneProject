namespace ScreenScene.Business.Interfaces;

public interface IGenreService<TRequest, TResponse> : IService<TRequest, TResponse> where TRequest : class where TResponse : class
{
    
}