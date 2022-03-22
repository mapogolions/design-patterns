using System;

namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public class ShoppingCartConfirmed : IShoppingCartEvent
    {
        public Guid ShoppingCartId { get; init; }
        public DateTime ConfirmedAt { get; init; }

        public void Accept(IShoppingCartEventVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
