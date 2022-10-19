using Microsoft.EntityFrameworkCore;
using Webstore.Services.Products.Application.Common.Interfaces;
using Webstore.Services.Products.Domain;

namespace Webstore.Services.Products.Infrastructure.Persistence
{
    public class ProductDbContext : DbContext, IProductDbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public ProductDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasKey(t => t.Id);

            modelBuilder
                .Entity<Product>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
