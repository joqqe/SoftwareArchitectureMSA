using MediatR;
using Webstore.Services.Products.Contracts.Dtos;

namespace Webstore.Services.Products.Application.Internal.Queries.GetProductMessage
{
    public class GetProductMessageQuery : Contracts.Messages.GetProductMessage, IRequest<GetProductContract>
    {
    }
}
