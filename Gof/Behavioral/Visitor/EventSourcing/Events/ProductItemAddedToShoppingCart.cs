using System;

namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public class ProductItemAddedToShoppingCart : IShoppingCartEvent
    {
        public Guid ShoppingCartId { get; init; }
        public ProductItem ProductItem { get; init; }

        public void Apply(IShoppingCartEventVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
