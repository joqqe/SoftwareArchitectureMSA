namespace Webstore.Services.Orders.Application.External.Commands.Dtos
{
    public class CreateOrderLineDto
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
