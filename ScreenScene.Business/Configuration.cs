using Microsoft.Extensions.DependencyInjection;
using ScreenScene.Business.Interfaces;
using ScreenScene.Business.MapperConfiguration;
using ScreenScene.Business.Services;

namespace ScreenScene.Business
{
    public static class Configuration
    {
        public static void Configure(this IServiceCollection serviceCollection, string connectionString)
        {
            Data.Configuration.Configure(serviceCollection, connectionString);

            serviceCollection.AddAutoMapper(typeof(MapperProfile));

            serviceCollection.AddTransient<IActorService, ActorService>();
        }
    }
}
