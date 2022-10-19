using Webstore.Services.Products.Contracts.Dtos;
using Webstore.Services.Products.Contracts.Messages;

namespace Webstore.Services.Orders.Application.Common.Interfaces
{
    public interface IProductService
    {
        Task<GetProductContract> GetProductsAsync(GetProductMessage request);
    }
}