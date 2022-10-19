using Webstore.Services.Products.Contracts.Dtos;
using Webstore.Services.Products.Contracts.Messages;

namespace Webstore.Services.Products.Contracts
{
    public abstract class ProductContract
    {
        public static string GetProductsUrl(string id) => $"api/internal/product/{id}";
        public abstract Task<GetProductContract> GetProductsAsync(GetProductMessage request);
    }
}
