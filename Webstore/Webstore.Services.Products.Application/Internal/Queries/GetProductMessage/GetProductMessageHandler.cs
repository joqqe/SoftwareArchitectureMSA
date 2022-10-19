using MediatR;
using Microsoft.EntityFrameworkCore;
using Webstore.Services.Products.Application.Common.Exceptions;
using Webstore.Services.Products.Application.Common.Interfaces;
using Webstore.Services.Products.Contracts.Dtos;
using Webstore.Services.Products.Domain;

namespace Webstore.Services.Products.Application.Internal.Queries.GetProductMessage
{
    public class GetProductMessageHandler : IRequestHandler<GetProductMessageQuery, GetProductContract>
    {
        private readonly IProductDbContext dbContext;

        public GetProductMessageHandler(IProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GetProductContract> Handle(GetProductMessageQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken)
                is Product product 
                    ? new GetProductContract((int)product.Id!, product.Name, product.Prize)
                    : throw new NotFoundException($"Product with id:{request.Id} does not exsist.");
        }
    }
}
