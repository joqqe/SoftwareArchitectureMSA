using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Webstore.Services.Products.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
