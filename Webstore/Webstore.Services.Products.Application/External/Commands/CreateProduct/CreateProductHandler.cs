using MediatR;
using Webstore.Services.Products.Application.Common.Interfaces;
using Webstore.Services.Products.Domain;

namespace Webstore.Services.Products.Application.External.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IProductDbContext productDbContext;

        public CreateProductHandler(IProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Product(null, request.Name, request.Prize);

            await productDbContext.Products.AddAsync(newProduct);
            await productDbContext.SaveChangesAsync(cancellationToken);

            return await Unit.Task;
        }
    }
}
