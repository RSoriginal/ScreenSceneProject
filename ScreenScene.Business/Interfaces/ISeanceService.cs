namespace ScreenScene.Business.Interfaces;

public interface ISeanceService<TRequest, TResponse> : IService<TRequest, TResponse> where TRequest : class where TResponse : class
{
    
}