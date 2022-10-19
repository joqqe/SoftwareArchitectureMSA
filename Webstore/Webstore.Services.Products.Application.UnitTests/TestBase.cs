using Microsoft.Extensions.DependencyInjection;
using Webstore.Services.Products.Domain;
using Webstore.Services.Products.Infrastructure;
using Webstore.Services.Products.Infrastructure.Persistence;

namespace Webstore.Services.Products.Application.UnitTests
{
    public abstract class TestBase : IDisposable
    {
        public readonly ServiceProvider serviceProvider;

        public TestBase()
        {
            var services = new ServiceCollection();
            services.AddApplication();
            services.AddInfrastructure();

            serviceProvider = services.BuildServiceProvider();

            // Create BD & Seed
            var todoDbContext = GetScopedTodoDbContext();
            todoDbContext.Database.EnsureCreated();
            todoDbContext.Products.AddRange(
                new Product(Id: 1, Name: "Banana", Prize: 0.1m),
                new Product(Id: 2, Name: "Apple", Prize: 0.2m),
                new Product(Id: 3, Name: "Orange", Prize: 0.3m));
            todoDbContext.SaveChanges();
        }

        public void Dispose()
        {
            GetScopedTodoDbContext().Database.EnsureDeleted();
        }

        private ProductDbContext GetScopedTodoDbContext()
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            var scope = scopeFactory.CreateScope();
            return scope.ServiceProvider.GetService<ProductDbContext>()!;
        }
    }
}
