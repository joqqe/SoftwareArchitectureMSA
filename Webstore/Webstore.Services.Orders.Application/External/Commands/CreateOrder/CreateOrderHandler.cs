using MediatR;
using Webstore.Services.Orders.Application.Common.Interfaces;
using Webstore.Services.Orders.Domain;
using Webstore.Services.Products.Contracts.Dtos;

namespace Webstore.Services.Orders.Application.External.Commands.CreateOrderCommand
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Unit>
    {
        private readonly IOrderDbContext orderDbContext;
        private readonly IProductService productService;

        public CreateOrderHandler(IOrderDbContext orderDbContext, IProductService productService)
        {
            this.orderDbContext = orderDbContext;
            this.productService = productService;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var uniqueProductIds = request.OrderLines.Select(o => o.ProductId).Distinct();
            var productDetails = new List<GetProductContract>();

            foreach (var uniqueProductId in uniqueProductIds)
            {
                var productDetail = await productService.GetProductsAsync(
                    new Products.Contracts.Messages.GetProductMessage
                    {
                        Id = uniqueProductId
                    });

                productDetails.Add(productDetail);
            }

            var newOrder = new Order
            {
                User = request.User,
                OrderLines = request.OrderLines.Select(o => new OrderLine
                {
                    ProductId = o.ProductId,
                    Count = o.Count,
                    UnitPrize = productDetails.FirstOrDefault(p => p.Id == o.ProductId)?.Prize
                        ?? throw new Exception($"Prize not found of product with id:{o.ProductId}")
                }).ToArray()
            };

            await orderDbContext.Orders.AddAsync(newOrder);
            await orderDbContext.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
