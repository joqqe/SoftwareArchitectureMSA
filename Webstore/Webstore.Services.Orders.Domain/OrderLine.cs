﻿namespace Webstore.Services.Orders.Domain
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal UnitPrize { get; set; }
    }
}
