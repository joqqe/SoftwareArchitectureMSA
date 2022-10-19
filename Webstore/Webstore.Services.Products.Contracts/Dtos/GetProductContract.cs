namespace Webstore.Services.Products.Contracts.Dtos
{
    public class GetProductContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Prize { get; set; }

        public GetProductContract(int id, string name, decimal prize)
        {
            Id = id;
            Name = name;
            Prize = prize;
        }
    }
}
