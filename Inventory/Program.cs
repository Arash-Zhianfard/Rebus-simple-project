using CustomerService;
using Microsoft.Extensions.Configuration;
using Serilog;
using Topper;

namespace Processor
{
    static class Program
    {
        private static IConfiguration Configuration { get; set; }

        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .CreateLogger();

            ReadConfiguration();

            var serviceConfiguration = new ServiceConfiguration()
               .Add("RebusConfig", () => new RebusConfig(Configuration));

            ServiceHost.Run(serviceConfiguration);
        }

        private static void ReadConfiguration()
        {
            var builder =
                new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false);
            Configuration = builder.Build();
        }
    }
}