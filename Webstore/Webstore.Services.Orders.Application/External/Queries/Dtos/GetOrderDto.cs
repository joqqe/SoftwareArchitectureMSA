namespace Webstore.Services.Orders.Application.External.Queries.Dtos
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public GetOrderLineDto[] OrderLines { get; set; }
    }
}
