using MediatR;
using Webstore.Services.Orders.Application.External.Queries.Dtos;

namespace Webstore.Services.Orders.Application.External.Queries.GetOrders
{
    public class GetOrdersQuery : IRequest<GetOrderDto[]>
    {
    }
}
