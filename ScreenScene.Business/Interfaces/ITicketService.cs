namespace ScreenScene.Business.Interfaces;

public interface ITicketService<TRequest, TResponse> : IService<TRequest, TResponse> where TRequest : class where TResponse : class
{
    
}