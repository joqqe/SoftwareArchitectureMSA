using System.Text.Json;
using Webstore.Services.Orders.Application.Common.Interfaces;
using Webstore.Services.Products.Contracts;
using Webstore.Services.Products.Contracts.Dtos;
using Webstore.Services.Products.Contracts.Messages;

namespace Webstore.Services.Orders.Infrastructure.Services
{
    public class ProductService : ProductContract, IProductService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly JsonSerializerOptions serializeOptions;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;

            serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public override async Task<GetProductContract> GetProductsAsync(GetProductMessage request)
        {
            var httpClient = httpClientFactory.CreateClient("Products");

            var httpResponse = await httpClient.GetAsync(GetProductsUrl(request.Id.ToString()!));

            if (!httpResponse.IsSuccessStatusCode)
                throw new Exception("Product not found.");

            var contentString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<GetProductContract>(contentString, serializeOptions)
                ?? throw new Exception("Product not found.");
        }
    }
}
