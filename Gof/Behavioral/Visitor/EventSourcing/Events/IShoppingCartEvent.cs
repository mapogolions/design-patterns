namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public interface IShoppingCartEvent : IAggregateEvent<IShoppingCartEventVisitor> { }
}
