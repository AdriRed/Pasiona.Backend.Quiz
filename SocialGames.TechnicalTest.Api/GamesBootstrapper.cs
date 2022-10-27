using Microsoft.Extensions.DependencyInjection;

namespace SocialGames.TechnicalTest.Api
{
    public class GamesBootstrapper
    {
        IServiceCollection _serviceCollection;

        public GamesBootstrapper(IServiceCollection collection)
        {
            _serviceCollection = collection;
        }

        public void Run()
        {
            RegisterServices();
        }

        protected void RegisterServices()
        {

        }
    }
}
