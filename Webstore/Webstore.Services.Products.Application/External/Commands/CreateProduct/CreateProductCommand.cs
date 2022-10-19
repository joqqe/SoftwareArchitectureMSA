using MediatR;

namespace Webstore.Services.Products.Application.External.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public decimal Prize { get; set; }
    }
}
