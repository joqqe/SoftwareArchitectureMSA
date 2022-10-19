namespace Webstore.Services.Orders.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string User { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}
