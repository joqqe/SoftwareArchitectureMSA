namespace Webstore.Services.Products.Application.External.Dtos
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Prize { get; set; }
    }
}
