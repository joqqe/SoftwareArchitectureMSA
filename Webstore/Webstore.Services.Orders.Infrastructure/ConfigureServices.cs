using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webstore.Services.Orders.Application.Common.Interfaces;
using Webstore.Services.Orders.Infrastructure.Persistence;
using Webstore.Services.Orders.Infrastructure.Services;

namespace Webstore.Services.Orders.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseSqlite(connection);
            });

            services.AddScoped<IOrderDbContext>(collection => collection.GetRequiredService<OrderDbContext>());

            services.AddHttpClient("Products", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://localhost:30003");
            });

            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
