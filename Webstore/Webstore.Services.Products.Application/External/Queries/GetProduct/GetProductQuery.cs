using MediatR;
using Webstore.Services.Products.Application.External.Dtos;

namespace Webstore.Services.Products.Application.External.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductDto>
    {
        public int? Id { get; set; }
    }
}
