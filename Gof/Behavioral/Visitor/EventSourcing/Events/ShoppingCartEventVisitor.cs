using System;

namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public interface IShoppingCartEventVisitor
    {
        // void Visit(ShoppingCartOpened @event);
    }

    public class ShoppingCartEventVisitor : IShoppingCartEventVisitor
    {
    }
}
