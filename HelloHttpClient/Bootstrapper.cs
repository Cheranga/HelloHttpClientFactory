using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace HelloHttpClient
{
    public static class Bootstrapper
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddHttpClient<ITodoService, TodoService>();

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
