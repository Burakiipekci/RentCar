using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        //Injection kontrol edip yakalamak için yazdık.
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
