using System;
using System.Collections.Generic;
using Gof.Behavioral.Visitor.EventSourcing.Events;

namespace Gof.Behavioral.Visitor.EventSourcing
{
    public class ShoppingCart
    {
        private readonly IShoppingCartEventVisitor _visitor;

        public ShoppingCart(IShoppingCartEventVisitor visitor)
        {
            _visitor = visitor;
        }

        public void Aggreagate(IEnumerable<IShoppingCartEvent> events)
        {
            foreach (var @event in events)
            {
                @event.Accept(_visitor);
            }
        }

        public Guid Id { get; protected set; }
        public Guid ClientId { get; protected set; }
        public ShoppingCartStatus Status { get; protected set; }
        public IList<ProductItem> ProductItems { get; protected set; } = new List<ProductItem>();
        public DateTime? ConfirmedAt { get; protected set; }
        public DateTime? CanceledAt { get; protected set; }
    }
}
