using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Webstore.Services.Orders.Application.Common.Interfaces;
using Webstore.Services.Orders.Domain;

namespace Webstore.Services.Orders.Infrastructure.Persistence
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        public DbSet<Order> Orders => Set<Order>();

        public OrderDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
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
                .Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder
                .Entity<Order>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<OrderLine>()
                .HasKey(o => o.Id);

            modelBuilder
                .Entity<OrderLine>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
