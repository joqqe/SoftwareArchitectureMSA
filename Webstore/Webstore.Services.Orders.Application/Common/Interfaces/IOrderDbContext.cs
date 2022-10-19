using Microsoft.EntityFrameworkCore;
using Webstore.Services.Orders.Domain;

namespace Webstore.Services.Orders.Application.Common.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Order> Orders { get; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
