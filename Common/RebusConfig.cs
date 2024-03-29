﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rebus.Bus;
using Rebus.Config;
using Rebus.ServiceProvider;

namespace Common
{
    public class RebusConfig : IDisposable
    {
        private  ServiceProvider _provider;
        private IBus _bus;

        public RebusConfig(IConfiguration configuration)
        {
            var services = new ServiceCollection();
            services.AddRebusService(configuration);
            _provider = services.BuildServiceProvider();
            _provider.StartRebus();
        }

        public void Dispose()
        {
            _bus?.Dispose();
            _provider?.Dispose();
        }
    }
}
