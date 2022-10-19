using MediatR;
using Webstore.Services.Products.Application.External.Dtos;

namespace Webstore.Services.Products.Application.External.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<GetProductDto[]>
    {
    }
}
