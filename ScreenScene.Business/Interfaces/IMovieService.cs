namespace ScreenScene.Business.Interfaces;

public interface IMovieService<TRequest, TResponse> : IService<TRequest, TResponse> where TRequest : class where TResponse : class
{
    
}