using System.Collections.Generic;
using Gof.Behavioral.Visitor.EventSourcing.Events;

namespace Gof.Behavioral.Visitor.EventSourcing
{
    public class ShoppingCartBuilder : IAggregateBuilder<ShoppingCart, IShoppingCartEvent, IShoppingCartEventVisitor>
    {
        private readonly IShoppingCartEventVisitor _visitor;

        public ShoppingCart Build(IEnumerable<IShoppingCartEvent> events)
        {
            var shoppingCart = new ShoppingCart(_visitor);
            shoppingCart.Aggregate(events);
            return shoppingCart;
        }
    }
}
