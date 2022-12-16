using Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Bus;
using Rebus.ServiceProvider;

namespace CustomerService
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
            _provider.UseRebus(x => _bus = x);
        }

        public void Dispose()
        {
            _bus?.Dispose();
            _provider?.Dispose();
        }
    }
}
