using MediatR;
using Webstore.Services.Orders.Application.External.Commands.Dtos;

namespace Webstore.Services.Orders.Application.External.Commands.CreateOrderCommand
{
    public class CreateOrderCommand : IRequest<Unit>
    {
        public string User { get; set; }
        public CreateOrderLineDto[] OrderLines { get; set; }
    }
}
