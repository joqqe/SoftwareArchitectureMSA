using MediatR;
using Microsoft.EntityFrameworkCore;
using Webstore.Services.Products.Application.Common.Interfaces;
using Webstore.Services.Products.Application.External.Dtos;

namespace Webstore.Services.Products.Application.External.Queries.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, GetProductDto[]>
    {
        private readonly IProductDbContext dbContext;

        public GetProductsHandler(IProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<GetProductDto[]> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return dbContext.Products
                .AsNoTracking()
                .Select(p => new GetProductDto 
                { 
                    Id = (int)p.Id,
                    Name = p.Name,
                    Prize = p.Prize
                })
                .ToArrayAsync();
        }
    }
}
