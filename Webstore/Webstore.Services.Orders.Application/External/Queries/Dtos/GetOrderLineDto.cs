namespace Webstore.Services.Orders.Application.External.Queries.Dtos
{
    public class GetOrderLineDto
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal UnitPrize { get; set; }
    }
}
