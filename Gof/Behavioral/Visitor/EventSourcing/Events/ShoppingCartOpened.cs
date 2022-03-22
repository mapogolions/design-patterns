using System;

namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public class ShoppingCartOpened : IShoppingCartEvent
    {
        public Guid ShoppingCartId { get; init; }
        public Guid ClientId { get; init; }

        public void Accept(IShoppingCartEventVisitor visitor) => throw new NotImplementedException();
    }
}
