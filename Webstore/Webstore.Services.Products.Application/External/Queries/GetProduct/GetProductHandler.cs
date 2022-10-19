using MediatR;
using Webstore.Services.Products.Application.External.Dtos;

namespace Webstore.Services.Products.Application.External.Queries.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductDto>
    {
        public Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
