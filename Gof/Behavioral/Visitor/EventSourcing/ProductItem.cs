using System;

namespace Gof.Behavioral.Visitor.EventSourcing
{
    public class ProductItem
    {
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
