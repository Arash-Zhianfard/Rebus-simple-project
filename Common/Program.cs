using Microsoft.Extensions.Configuration;
using Serilog;
using Topper;

namespace Common
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
               .Add("OurBackendBus", () => new RebusConfig(Configuration));

            ServiceHost.Run(serviceConfiguration);
        }

        private static void ReadConfiguration()
        {
            var builder =
                new ConfigurationBuilder();                   
            Configuration = builder.Build();
        }
    }
}
