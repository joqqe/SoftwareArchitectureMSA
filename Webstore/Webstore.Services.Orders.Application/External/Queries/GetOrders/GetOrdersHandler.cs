using MediatR;
using Microsoft.EntityFrameworkCore;
using Webstore.Services.Orders.Application.Common.Interfaces;
using Webstore.Services.Orders.Application.External.Queries.Dtos;

namespace Webstore.Services.Orders.Application.External.Queries.GetOrders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, GetOrderDto[]>
    {
        private readonly IOrderDbContext orderDbContext;

        public GetOrdersHandler(IOrderDbContext orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        public Task<GetOrderDto[]> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return orderDbContext.Orders
                .AsNoTracking()
                .Select(o => new GetOrderDto
                {
                    Id = o.Id,
                    User = o.User,
                    OrderLines = o.OrderLines.Select(ol => new GetOrderLineDto
                    {
                        ProductId = ol.ProductId,
                        Count = ol.Count,
                        UnitPrize = ol.UnitPrize
                    }).ToArray()
                })
                .ToArrayAsync();
        }
    }
}
