using CustomerService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Auditing.Messages;
using Rebus.Config;
using Rebus.Persistence.InMem;
using Rebus.Retry.Simple;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;

namespace Common
{
    public static class RebusService
    {
        public static void AddRebusService(this IServiceCollection services, IConfiguration config)
        {
            services.AddRebus(
                rebus => rebus
                   .Logging(l => l.Serilog())
                        .Routing(r =>
                        {
                            r.TypeBased()
                                .MapAssemblyOf<SendEmail>("MainQueue");
                        })
                   .Transport(t => t.UseRabbitMq("amqp://localhost", "MainQueue")).Timeouts(t => t.StoreInMemory())
                   .Options(t => t.SimpleRetryStrategy(errorQueueAddress: "ErrorQueue"))
                   .Options(t => t.EnableMessageAuditing(auditQueue: "AuditQueue")));

            services.AutoRegisterHandlersFromAssemblyOf<RebusConfig>();
        }
    }
}
