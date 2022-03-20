namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public interface IShoppingCartEvent
    {
        void Accept(IShoppingCartEventVisitor visitor);
    }
}
