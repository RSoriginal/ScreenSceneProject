namespace ScreenScene.Business.Interfaces;

public interface IGradeService<TRequest, TResponse> : IService<TRequest, TResponse> where TRequest : class where TResponse : class
{
    
}