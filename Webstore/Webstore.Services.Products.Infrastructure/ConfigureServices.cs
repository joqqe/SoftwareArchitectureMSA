using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webstore.Services.Products.Application.Common.Interfaces;
using Webstore.Services.Products.Infrastructure.Persistence;

namespace Webstore.Services.Products.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlite(connection);
            });

            services.AddScoped<IProductDbContext>(collection => collection.GetRequiredService<ProductDbContext>());

            return services;
        }
    }
}
