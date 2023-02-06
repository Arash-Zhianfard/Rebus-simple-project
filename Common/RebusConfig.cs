using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Bus;
using Rebus.ServiceProvider;

namespace Common
{
    public class RebusConfig : IDisposable
    {
        private readonly ServiceProvider _provider;
        private IBus _bus;

        public RebusConfig(IConfiguration configuration)
        {
            var services = new ServiceCollection();
            services.AddRebusService(configuration);
            _provider = services.BuildServiceProvider();            
        }

        public void Dispose()
        {
            _bus?.Dispose();
            _provider?.Dispose();
        }
    }
}
