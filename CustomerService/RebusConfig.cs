using Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Auditing.Messages;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Persistence.InMem;
using Rebus.Retry.Simple;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;
using Rebus.Transport.InMem;

namespace CustomerService
{
    public class RebusConfig : IDisposable
    {
        private readonly ServiceProvider _provider;
        private IBus _bus;
        
        public RebusConfig(IConfiguration configuration)
        {
            var network = new InMemNetwork();
            var services = new ServiceCollection();            
            services.AddRebus(
                rebus => rebus
                   .Logging(l => l.Serilog())
                        .Routing(r =>
                        {
                            r.TypeBased()
                                .MapAssemblyOf<SendEmail>("MainQueue");
                        })
                   .Transport(t => t.UseInMemoryTransport(network, "MainQueue")).Timeouts(t => t.StoreInMemory())
                   .Options(t => t.SimpleRetryStrategy(errorQueueAddress: "ErrorQueue"))
                   .Options(t => t.EnableMessageAuditing(auditQueue: "AuditQueue")));
            services.AutoRegisterHandlersFromAssemblyOf<RebusConfig>();
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
