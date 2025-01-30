namespace ScreenScene.Business.Interfaces;

public interface IPropositionService<TRequest, TResponse> : IService<TRequest, TResponse> where TRequest : class where TResponse : class
{
    
}