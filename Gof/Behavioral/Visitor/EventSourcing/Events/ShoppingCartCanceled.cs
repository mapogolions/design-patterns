using System;

namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public class ShoppingCartCanceled : IShoppingCartEvent
    {
        public Guid ShoppingCartId { get; init; }
        public DateTime CanceledAt { get; init; }

        public void Accept(IShoppingCartEventVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
