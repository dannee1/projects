using DBServer.Ioc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBServer.Injector.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInjectorBootstrapper(this IServiceCollection services, IConfiguration configuration)
        {
            InjectorBootstrapper.RegisterServices(services, configuration);
        }
    }
}
