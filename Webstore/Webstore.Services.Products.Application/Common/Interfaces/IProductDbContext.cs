using Microsoft.EntityFrameworkCore;
using Webstore.Services.Products.Domain;

namespace Webstore.Services.Products.Application.Common.Interfaces
{
    public interface IProductDbContext
    {
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
