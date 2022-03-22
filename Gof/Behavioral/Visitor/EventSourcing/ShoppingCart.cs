using System;
using System.Collections.Generic;
using Gof.Behavioral.Visitor.EventSourcing.Events;

namespace Gof.Behavioral.Visitor.EventSourcing
{
    public class ShoppingCart : IAggregate<IShoppingCartEventVisitor, IShoppingCartEvent>
    {
        private readonly IShoppingCartEventVisitor _visitor;

        public ShoppingCart(IShoppingCartEventVisitor visitor)
        {
            _visitor = visitor;
        }

        public void Aggregate(IEnumerable<IShoppingCartEvent> events)
        {
            foreach (var @event in events)
            {
                @event.Accept(_visitor);
            }
        }

        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public ShoppingCartStatus Status { get; set; }
        public IList<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
        public DateTime? ConfirmedAt { get; set; }
        public DateTime? CanceledAt { get; set; }
    }
}
