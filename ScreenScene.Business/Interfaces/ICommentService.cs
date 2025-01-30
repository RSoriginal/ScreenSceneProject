namespace ScreenScene.Business.Interfaces;

public interface ICommentService<TRequest, TResponse> : IService<TRequest, TResponse> where TRequest : class where TResponse : class
{
    
}