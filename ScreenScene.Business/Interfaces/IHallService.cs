namespace ScreenScene.Business.Interfaces;

public interface IHallService<TRequest, TResponse> : IService<TRequest, TResponse> where TRequest : class where TResponse : class
{
    
}