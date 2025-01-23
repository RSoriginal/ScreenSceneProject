using Microsoft.Extensions.DependencyInjection;

namespace ScreenScene.Business
{
    public static class Configuration
    {
        public static void Configure(this IServiceCollection serviceCollection, string connectionString)
        {
            Data.Configuration.Configure(serviceCollection, connectionString);
        }
    }
}
